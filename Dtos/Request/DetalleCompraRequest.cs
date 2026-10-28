using System.ComponentModel.DataAnnotations;
namespace AbarrotesHogar.Dtos.Request;
public class DetalleCompraRequest
{
    [Required(ErrorMessage = "El ID de la compra es obligatorio")]
    public int Id_compra{get;set;}
    [Required(ErrorMessage = "El ID del producto es obligatorio")]
    public int Id_producto{get;set;}
    [Required(ErrorMessage = "La cantidad es obligatoria")]
    [Range(1,int.MaxValue, ErrorMessage ="La cantidad debe ser mayor a cero")]
    public int Cantidad {get;set;}
    [Required(ErrorMessage = "El precio unitario es obligatorio")]
    [Range(0.01,double.MaxValue,ErrorMessage = "El precio unitario debe ser mayor que cero")]
    public decimal Precio_unitario{get;set;}
    [Required(ErrorMessage = "El subtotal es obligatorio")]
    [Range(0.01,double.MaxValue,ErrorMessage = "El subtotal debe ser mayor que cero")]
    public decimal Subtotal {get;set;} 
}