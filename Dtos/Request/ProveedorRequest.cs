using System.ComponentModel.DataAnnotations;
namespace AbarrotesHogar.Dtos.Request;
public class ProveedorRequest
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(150, ErrorMessage = "El nombre no puede superar los 150 caracteres.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El RUC es obligatorio.")]
    [RegularExpression(@"^(10|20)\d{9}$", ErrorMessage = "El RUC debe tener 11 dígitos y empezar con 10 o 20.")] 
    public string? Ruc { get; set; }

    [Phone(ErrorMessage = "El formato del teléfono no es válido.")]
    [StringLength(20, ErrorMessage = "El teléfono no puede superar los 20 caracteres.")]
    public string? Telefono { get; set; }

    [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres.")]
    public string? Direccion { get; set; }

    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
    [StringLength(100, ErrorMessage = "El correo no puede superar los 100 caracteres.")]
    public string? Correo { get; set; }

    public bool Estado { get; set; }
}