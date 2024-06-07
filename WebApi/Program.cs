using Application.Configurations;
using Data.Data;
using Data.Repositories;
using Domain.Models.Administrators;
using Domain.Models.Customers;
using Domain.Models.DairyExchange;
using Domain.Models.MilkDeliveries;
using Domain.Models.Stores;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<DataContext>(
    option=>option.UseSqlServer(connection));
builder.Services.AddTransient<IAdminRepository,AdminRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IStoreRepository, StoreRepository>();
builder.Services.AddTransient<IMilkDeliveryRepository, MilkDeliveryRepository>();
builder.Services.AddTransient<IDairyExchangeRepository, DairyExchangeRepository>();




builder.Services.AddAutoMapper(typeof(ManagingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
