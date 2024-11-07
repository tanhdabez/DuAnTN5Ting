using DemoBanQuanAo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// AddDbContext with SQL Server provider
builder.Services.AddDbContext<DbContextShop>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCS")));

// Add session service
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{controller=Admin}/{action=Admin}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.Run();
