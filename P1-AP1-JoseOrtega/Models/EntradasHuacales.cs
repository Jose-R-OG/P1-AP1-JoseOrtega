using System.ComponentModel.DataAnnotations;

namespace P1_AP1_JoseOrtega.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }
    [Required(ErrorMessage = "El campo nombre es obligatorio")]
    public string NombreCliente { get; set; }
    [Required(ErrorMessage = "El Campo fecha es obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "La cantidad de huacales es un campo obligatorio")]
    [Range(0, int.MaxValue, ErrorMessage ="La cantidad no puede ser un valor negativo")]
    public int  Cantidad { get; set; }
    [Required(ErrorMessage = "El precio es un campo obligatorio")]
    [Range(0, double.MaxValue, ErrorMessage = "El precio no puede ser un valor negativo")]
    public double Precio { get; set; }
}
