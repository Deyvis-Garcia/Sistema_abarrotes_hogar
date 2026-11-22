using System.ComponentModel.DataAnnotations;
namespace AbarrotesHogar.Dtos.Request;
public class AuthRequest
{
    [Required(ErrorMessage ="El usuario es obligatorio para iniciar session")]
    public string? Usuario{get;set;}
    [Required(ErrorMessage ="La contraseña es obligatoria para iniciar session")]
    public string? Contraseña{get;set;}
}