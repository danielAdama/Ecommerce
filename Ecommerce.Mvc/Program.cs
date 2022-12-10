using Ecommerce.Mvc.Infrastructure;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;
using Ecommerce.Infrastructure.Services.Infrastructure.Persistence;
using Ecommerce.Infrastructure.Services.Infrastructure.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterApplication();
builder.Services.RegisterPersistence(builder.Configuration);
builder.Services.RegisterIdentity();
builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

//app.MapControllerRoute(
//    name: "MyArea",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//);

app.MapAreaControllerRoute(
            name: "MyAreaAccounts",
            areaName: "Accounts",
            pattern: "Accounts/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
            name: "MyAreaProducts",
            areaName: "Products",
            pattern: "Products/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
            name: "MyAreaOrders",
            areaName: "Orders",
            pattern: "Orders/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
     name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}"
);

app.Run();
