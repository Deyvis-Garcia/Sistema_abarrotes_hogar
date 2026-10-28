using Microsoft.EntityFrameworkCore;
using AbarrotesHogar.Data;
using AbarrotesHogar.Repository;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services;
using AbarrotesHogar.Services.Interfaces;
using AbarrotesHogar.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//Registrar el DbContext con SQL Server
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
// Inyeccion de repositorios
builder.Services.AddScoped<IRepositoryCompras, RepositoryCompras>();
builder.Services.AddScoped<IRepositoryDetalleCompra, RepositoryDetalleCompra>();
builder.Services.AddScoped<IRepositoryDetalleVenta, RepositoryDetalleVenta>();
builder.Services.AddScoped<IRepositoryInventarioLotes, RepositoryInventarioLotes>();
builder.Services.AddScoped<IRepositoryProductos, RepositoryProductos>();
builder.Services.AddScoped<IRepositoryProveedores,RepositoryProveedores>();
builder.Services.AddScoped<IRepositoryUsuarios,RepositoryUsuarios>();
builder.Services.AddScoped<IRepositoryVentas, RepositoryVentas>();
//Inyeccion de servicios
builder.Services.AddScoped<IServicesCompras, ServicesCompras>();
builder.Services.AddScoped<IServicesDetalleCompra, ServicesDetalleCompra>();
builder.Services.AddScoped<IServicesDetalleVenta, ServicesDetalleVenta>();
builder.Services.AddScoped<IServicesInventarioLotes, ServicesInventarioLotes>();
builder.Services.AddScoped<IServicesProducto, ServicesProducto>();
builder.Services.AddScoped<IServicesProveedor,ServicesProveedor>();
builder.Services.AddScoped<IServicesUsuarios,ServicesUsuarios>();
builder.Services.AddScoped<IServicesVentas, ServicesVentas>();


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<ManejoErroresMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
