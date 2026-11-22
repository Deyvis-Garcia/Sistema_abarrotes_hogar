namespace AbarrotesHogar.Dtos.Response;

public class AuthResponse
{
    public int Id_usuario { get; set; }
    public string? Usuario { get; set; }
    public string? Rol { get; set; }
    public string Mensaje { get; set; } = "Inicio de sesión exitoso";
    public int Expiracion { get; set; }
    public string Token { get; set; } = string.Empty;
}