using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysTiendaDe.Models;

public partial class Servicio
{
    [Key]
    [Column("Servicio_Id")]
    public int ServicioId { get; set; }

    [Column("Servicio_Descripcion")]
    [StringLength(50)]
    [Unicode(false)]
    public string ServicioDescripcion { get; set; } = null!;

    [InverseProperty("Servicio")]
    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();
}
