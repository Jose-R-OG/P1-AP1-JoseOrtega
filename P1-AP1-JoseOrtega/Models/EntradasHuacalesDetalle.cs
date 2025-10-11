﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P1_AP1_JoseOrtega.Models;

public class EntradasHuacalesDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int EntradaId { get; set; }

    public int TipoId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad de huacales debe ser mayor que cero")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "El precio es un campo obligatorio")]
    [Range(0.01, int.MaxValue, ErrorMessage = "El precio de los huacales debe ser mayor que cero")]
    public double Precio { get; set; }

    [ForeignKey("IdEntrada")]
    [InverseProperty("EntradaHuacaleDetalle")]
    public virtual EntradasHuacales EntradaHuacale { get; set; } = null!;
}
