using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_RonnelDeLaCruz.Models;

public class PedidosDetalle
{
    [Key]
    public int Id { get; set; }

    public int PedidoId { get; set; }
    public int ComponenteId { get; set; }

    [ForeignKey("ComponenteId")]
    [InverseProperty("Detalles")]
    public Componente Componente { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Precio { get; set; }

    [ForeignKey("PedidoId")]
    [InverseProperty("Detalles")]
    public Pedidos Pedido { get; set; } = null!;
}
