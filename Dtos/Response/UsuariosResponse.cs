namespace AbarrotesHogar.Dtos.Response;
public class UsuariosResponse
{
    public int Id_usuario{get; set;}
    public string? Nombre{get;set;}
    public string? Apellido{get;set;}
    public string? Usuario{get;set;}
    public string? Contraseña{get;set;}
    public string? rol{get;set;}
    public bool Estado{get;set;}
}