using Microsoft.AspNetCore.Authentication.Cookies;
using WebAPIWithCoreMvc.ApiServices;
using WebAPIWithCoreMvc.ApiServices.Interfaces;
using WebAPIWithCoreMvc.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<AuthTokenHandler>();

#region HttpClient
builder.Services.AddHttpClient<IAuthApiService, AuthApiService>(opt =>
{
opt.BaseAddress = new Uri("http://localhost:63545/api/");
});
builder.Services.AddHttpClient<IUserApiService, UserApiService>(opt =>
{
    opt.BaseAddress = new Uri("http://localhost:63545/api/");
}).AddHttpMessageHandler<AuthTokenHandler>();
#endregion

#region Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
opt.LoginPath = "/Admin/Auth/Login";
opt.ExpireTimeSpan = TimeSpan.FromDays(60);
opt.SlidingExpiration = true;
opt.Cookie.Name = "mycookie";
}); 
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseExceptionHandler("/Home/Error");

app.UseStatusCodePagesWithRedirects("/Admin/Error/MyStatusCode?code={0}");

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    //Admin/Home/Index
    endpoints.MapAreaControllerRoute(
    areaName: "Admin",
    name: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
    );
});

// Home / Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
