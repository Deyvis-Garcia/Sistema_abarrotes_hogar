using System.ComponentModel.DataAnnotations;
namespace AbarrotesHogar.Dtos.Request;
public class UsuariosRequest
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres.")]
    public string? Apellido { get; set; }

    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    [StringLength(20, MinimumLength = 4, ErrorMessage = "El usuario debe tener entre 4 y 20 caracteres.")]
    public string? Usuario { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "La contraseña debe contener al menos una mayúscula, una minúscula y un número.")]
    public string? Contraseña { get; set; }

    [Required(ErrorMessage = "El rol es obligatorio.")]
    [RegularExpression(@"^(Administrador|Usuario|Vendedor)$", ErrorMessage = "El rol seleccionado no es válido.")] // Ajusta los roles según tu sistema
    public string? rol { get; set; }

    public bool Estado { get; set; }
}