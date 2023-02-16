using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ECommerceProjectWithWebAPIContext>(opts => 
opts.UseSqlServer("Data Source =.\\SQLEXPRESS;Initial Catalog = ECommerceProjectWithWebAPIDb;Integrated " +
"Security=True", options=>options.MigrationsAssembly("DataAccess").MigrationsHistoryTable
(HistoryRepository.DefaultTableName,"dbo")));

builder.Services.AddTransient<IUserDal, EfUserDal>();

builder.Services.AddTransient<IUserDal, EfUserDal>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
