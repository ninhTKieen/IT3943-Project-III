using AssetManagement.Data;
using AssetManagement.IOC;
using AssetManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
await builder.Services.Register(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddScoped<FilePermissionService>();
builder.Services.AddScoped<PermissionService>();
builder.Services.AddScoped<GrpcService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();