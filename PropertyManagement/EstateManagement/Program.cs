using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EstateManagement.DbContexts;
using EstateManagement.Mapper;
using EstateManagement.Services;

var builder = WebApplication.CreateBuilder(args);
IMapper mapper = MappingConfig.RegisterMap().CreateMapper();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<RealEstateTypeServices>();
builder.Services.AddScoped<RealEstateServices>();
builder.Services.AddScoped<MaintenanceHistoryServices>();

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