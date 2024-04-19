using CarStoreApplication.Services;
using CarStoreDataAccess.TestDbContext;
using CarStoreDataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FirstTestDbContext>(
    options =>{
        options.UseMySql(
            builder.Configuration.GetConnectionString(nameof(FirstTestDbContext))
            , ServerVersion.AutoDetect(builder.Configuration.GetConnectionString(nameof(FirstTestDbContext)))
            , null);
    });

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
