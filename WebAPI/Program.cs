using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Mappings;
using Core.Extensions;
using Core.Utilities.Security.Token;
using Core.Utilities.Security.Token.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddCustomJwtToken(Configuration);

#region AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

#region DI
builder.Services.AddTransient<IUserDal, EfUserDal>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITokenService, JwtTokenService>();
builder.Services.AddTransient<IAuthApiService, AuthApiService>();

#endregion

builder.Services.AddDbContext<ECommerceProjectWithWebAPIContext>(opts =>
opts.UseSqlServer("Data Source =.\\SQLEXPRESS;Initial Catalog = ECommerceProjectWithWebAPIDb;Integrated " +
"Security=True", options => options.MigrationsAssembly("DataAccess").MigrationsHistoryTable
(HistoryRepository.DefaultTableName, "dbo")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ECommerceProjectWithWebAPIContext>();
    context.Database.Migrate();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();




