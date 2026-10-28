using System.ComponentModel.DataAnnotations;
namespace AbarrotesHogar.Dtos.Request;
public class ComprasRequest
{
    [Required(ErrorMessage ="El ID del proveedor es obligatorio")]
    public int Id_proveedor { get; set; }
    [Required(ErrorMessage ="El ID del usuario es obligatorio")]
    public int Id_usuario { get; set; }
    [Required(ErrorMessage ="La fecha es obligatoria")]
    [DataType(DataType.Date)]
    public DateTime Fecha_compra { get; set; }
    [Required(ErrorMessage ="El total de la compra es obligatorio")]
    [Range(0.01,double.MaxValue,ErrorMessage ="El total debe ser un numero mayor a cero")]
    public decimal Total { get; set; }
    public string? Observaciones { get; set; }
}