using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTiendaDe.Models;

[Table("Detalle_Factura")]
public partial class DetalleFactura
{
    [Key]
    [Column("Detalle_Factura_Id")]
    public int DetalleFacturaId { get; set; }

    [Column("Factura_Id")]
    public int FacturaId { get; set; }

    [Column("Servicio_Id")]
    public int ServicioId { get; set; }

    public int Cantidad { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Precio { get; set; }

    [ForeignKey("FacturaId")]
    [InverseProperty("DetalleFactura")]
    public virtual Cliente Factura { get; set; } = null!;

    [ForeignKey("ServicioId")]
    [InverseProperty("DetalleFactura")]
    public virtual Servicio Servicio { get; set; } = null!;
}
