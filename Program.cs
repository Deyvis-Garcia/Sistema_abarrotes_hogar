using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
// Inyeccion del servicio de autenticacion
builder.Services.AddScoped<IServicesAuth, ServicesAuth>();

// Configuracion de autenticacion y validacion del token JWT
var claveJwt = builder.Configuration["Jwt:Key"]!;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveJwt))
        };
    });

builder.Services.AddAuthorization();

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

// Activacion del middleware de autenticacion del token antes de la autorizacion
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();