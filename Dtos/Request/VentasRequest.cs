using System.ComponentModel.DataAnnotations;
namespace AbarrotesHogar.Dtos.Request;
public class VentasRequest
{
    [Required(ErrorMessage = "El identificador de usuario es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El Id de usuario debe ser un número entero positivo válido.")]
    public int Id_usuario { get; set; }

    [Required(ErrorMessage = "La fecha de venta es obligatoria.")]
    [DataType(DataType.DateTime, ErrorMessage = "El formato de la fecha no es válido.")]
    public DateTime Fecha_venta { get; set; }

    [Required(ErrorMessage = "El total es obligatorio.")]
    [Range(0.00, double.MaxValue, ErrorMessage = "El total de la venta no puede ser un valor negativo.")]
    public decimal Total { get; set; }

    [StringLength(500, ErrorMessage = "Las observaciones no pueden superar los 500 caracteres.")]
    public string? Observaciones { get; set; }
}