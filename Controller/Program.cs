using Controller.Service;
using DemoBanQuanAo.Models;
using DemoBanQuanAo.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DbContextShop>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("MyCS")); });
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendApp",
        policy => policy.WithOrigins("https://localhost:7013")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontendApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
