using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_RonnelDeLaCruz.Models;

public class PedidosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int Id { get; set; }  
    public int ComponenteId { get; set; } 

    [ForeignKey("ComponenteId")]
    [InverseProperty("Detalles")]
    public Componente Componente { get; set; } = null!;

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
    public int Cantidad { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
    public decimal Precio { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Detalles")]
    public Registros Registro { get; set; } = null!;
}
