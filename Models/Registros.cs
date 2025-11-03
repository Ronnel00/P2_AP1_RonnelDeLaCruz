using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_AP1_RonnelDeLaCruz.Models;

public class Registros
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
    [StringLength(100)]
    public string Cliente { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "El total no puede ser negativo")]
    public decimal Total { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "La cantidad no puede ser negativa")]
    public int Cantidad { get; set; }

    [InverseProperty("Registro")]
    public virtual ICollection<PedidosDetalle> Detalles { get; set; } = new List<PedidosDetalle>();
}
