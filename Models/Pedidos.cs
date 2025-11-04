using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_RonnelDeLaCruz.Models;

public class Pedidos
{
    [Key]
    public int PedidoId { get; set; }

    [Required]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required, StringLength(100)]
    public string NombreCliente { get; set; } = string.Empty;

    [Range(0, double.MaxValue)]
    public decimal Total { get; set; }

    [InverseProperty("Pedido")]
    public virtual ICollection<PedidosDetalle> Detalles { get; set; } = new List<PedidosDetalle>();
}
