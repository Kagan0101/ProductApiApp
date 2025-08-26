
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Services;
using backend.Services.Interfaces;
using backend.Repositories;
using backend.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(9, 3, 0)) // MySQL versiyonunu yaz
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Next.js frontend
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend"); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
