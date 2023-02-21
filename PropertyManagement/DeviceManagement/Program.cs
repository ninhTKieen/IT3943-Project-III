using DeviceManagement.Data;
using DeviceManagement.IOC;
using DeviceManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//extra configuration
await builder.Services.Register(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<GrpcDeviceService>();
// app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MapGet("/Protos/device.proto", async context =>
{
    await context.Response.WriteAsync(File.ReadAllText("Protos/device.proto"));
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();