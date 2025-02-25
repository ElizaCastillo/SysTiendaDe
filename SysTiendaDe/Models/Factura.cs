using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTiendaDe.Models;

public partial class Factura
{
    [Key]
    [Column("Factura_Id")]
    public int FacturaId { get; set; }

    [Column("Cliente_Id")]
    public int ClienteId { get; set; }

    [Column("Fecha_Factura", TypeName = "datetime")]
    public DateTime FechaFactura { get; set; }

    [Column("Fecha_Vencimiento", TypeName = "datetime")]
    public DateTime FechaVencimiento { get; set; }

    [Column("Sud_Total_sin_iva", TypeName = "decimal(18, 0)")]
    public decimal SudTotalSinIva { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Descuento { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Iva { get; set; }

    [Column("Total_con_Iva", TypeName = "decimal(18, 0)")]
    public decimal TotalConIva { get; set; }

    [Column("Importe_pagado", TypeName = "decimal(18, 0)")]
    public decimal ImportePagado { get; set; }

    [Column("Importe_pagar", TypeName = "decimal(18, 0)")]
    public decimal ImportePagar { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Factura")]
    public virtual Cliente Cliente { get; set; } = null!;
}
