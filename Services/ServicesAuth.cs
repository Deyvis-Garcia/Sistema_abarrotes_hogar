using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AbarrotesHogar.Dtos.Request;
using AbarrotesHogar.Dtos.Response;
using AbarrotesHogar.Models;
using AbarrotesHogar.Repository.Interfaces;
using AbarrotesHogar.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace AbarrotesHogar.Services;

public class ServicesAuth : IServicesAuth
{
    private readonly IRepositoryUsuarios _repositoryUsuarios;
    private readonly IConfiguration _configuration;

    public ServicesAuth(IRepositoryUsuarios repositoryUsuarios, IConfiguration configuration)
    {
        _repositoryUsuarios = repositoryUsuarios;
        _configuration = configuration;
    }

    public AuthResponse Login(AuthRequest request)
    {
        Usuarios? usuario = _repositoryUsuarios.BuscarPorNombreUsuario(request.Usuario!);

        if (usuario == null || !usuario.Estado)
        {
            throw new UnauthorizedAccessException("Credenciales inválidas o usuario inactivo.");
        }

        bool passwordValida = BCrypt.Net.BCrypt.Verify(request.Contraseña, usuario.Contraseña);
        if (!passwordValida)
        {
            throw new UnauthorizedAccessException("Credenciales inválidas.");
        }

        int expireMinutes = int.TryParse(_configuration["Jwt:ExpireMinutes"], out int min) && min > 0
            ? min
            : 60;
        DateTime expiraEn = DateTime.UtcNow.AddMinutes(expireMinutes);
        string token = GenerarJwt(usuario, expiraEn);

        return new AuthResponse
        {
            Id_usuario = usuario.Id_usuario,
            Usuario = usuario.Usuario,
            Rol = usuario.rol,
            Mensaje = "Inicio de sesión exitoso",
            Expiracion = expireMinutes,
            Token = token
        };
    }

    private string GenerarJwt(Usuarios usuario, DateTime expiraEn)
    {
        string key = _configuration["Jwt:Key"]!;
        string issuer = _configuration["Jwt:Issuer"]!;
        string audience = _configuration["Jwt:Audience"]!;

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id_usuario.ToString()),
            new Claim(ClaimTypes.Name, usuario.Usuario ?? string.Empty),
            new Claim(ClaimTypes.Role, usuario.rol ?? "Usuario")
        };

        var tokenDescriptor = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expiraEn,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}