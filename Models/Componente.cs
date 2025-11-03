using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_RonnelDeLaCruz.Models;

public class Componente
{
    [Key]
    public int ComponenteId { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public int Existencia { get; set; }

    [InverseProperty("Componente")]
    public virtual ICollection<PedidosDetalle> Detalles { get; set; } = new List<PedidosDetalle>();
}
