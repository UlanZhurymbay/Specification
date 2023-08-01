using Microsoft.EntityFrameworkCore;
using Specification.Data;
using Specification.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
var path = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(path), ServiceLifetime.Scoped);
var assembly = Assembly.GetExecutingAssembly();

var types = assembly.GetTypes().Where(t => typeof(IStrategy).IsAssignableFrom(t) && !t.IsInterface);
foreach (var type in types)
{
    builder.Services.Add(new ServiceDescriptor(typeof(IStrategy), type, ServiceLifetime.Scoped));
}
//builder.Services.AddScoped<IStrategy, AddStrategy>();
//builder.Services.AddScoped<IStrategy, MultiplyStrategy>();
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

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
