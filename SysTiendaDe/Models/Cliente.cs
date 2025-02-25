using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTiendaDe.Models;

public partial class Cliente
{
    [Key]
    [Column("Cliente_Id")]
    public int ClienteId { get; set; }

    [Column("Cliente_Nombre")]
    [StringLength(50)]
    [Unicode(false)]
    public string ClienteNombre { get; set; } = null!;

    [Column("Cliente_Direccion")]
    [StringLength(50)]
    [Unicode(false)]
    public string ClienteDireccion { get; set; } = null!;

    [InverseProperty("Factura")]
    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();

    [InverseProperty("Cliente")]
    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();
}
