using System.ComponentModel.DataAnnotations;
namespace AbarrotesHogar.Dtos.Request;
public class InventarioLotesRequest
{
    [Required(ErrorMessage = "El ID del producto es obligatorio")]
    public int Id_producto{get;set;}
    [Required(ErrorMessage ="La fecha es obligatoria")]
    [DataType(DataType.Date)]
    public DateTime Fecha_ingreso{get;set;}
    [Required(ErrorMessage ="La fecha es obligatoria")]
    [DataType(DataType.Date)]
    public DateTime Fecha_vencimiento{get;set;}
    [Required(ErrorMessage = "La cantidad del lote es obligatorio")]
    [Range(0.01,double.MaxValue,ErrorMessage = "La cantidad de lote debe ser un numero mayor a cero")]
    public decimal Cantidad_lote{get;set;}
    [Required(ErrorMessage = "El precio unitario es obligatorio")]
    [Range(0.01,double.MaxValue,ErrorMessage = "El precio unitario debe ser mayor que cero")]
    public decimal Costo_unitario{get;set;}
}