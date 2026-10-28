using System.ComponentModel.DataAnnotations;
namespace AbarrotesHogar.Dtos.Request;

public class ProductoRequest
{
    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
    public string? Nombre { get; set; }

    [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El precio de venta es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio de venta debe ser mayor a cero.")]
    public decimal precio_venta { get; set; }

    [Required(ErrorMessage = "El stock actual es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock actual no puede ser negativo.")]
    public int stock_actual { get; set; }

    [Required(ErrorMessage = "El stock mínimo es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo no puede ser negativo.")]
    public int stock_minimo { get; set; }

    public bool Estado { get; set; }
}