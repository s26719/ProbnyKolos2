using Microsoft.EntityFrameworkCore;
using przykladowykolos.Context;
using przykladowykolos.Repositories;
using przykladowykolos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(
        "Server=DESKTOP-BHAFUI9\\SQLEXPRESS01;Database=master;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddScoped<IMuzykRepository, MuzykRepository>();
builder.Services.AddScoped<IMuzykSerivce, MuzykSerivce>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();

