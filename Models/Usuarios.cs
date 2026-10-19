namespace AbarrotesHogar.Models;
public class Usuarios
{
    public int Id_usuario{get;private  set;}
    public string? Nombre{get;set;}
    public string? Apellido{get;set;}
    public string? Usuario{get;set;}
    public string? Contraseña{get;set;}
    public string? rol{get;set;}
    public bool Estado{get;set;} = true;
}