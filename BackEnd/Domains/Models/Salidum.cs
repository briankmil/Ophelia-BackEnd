using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Domains.Models
{
    [Table("SALIDA")]
    public partial class Salidum
    {
        [Key]
        [Column("SAL_id")]
        public int SalId { get; set; }
        [Column("SAL_idProducto")]
        public int SalIdProducto { get; set; }
        [Column("SAL_fecha", TypeName = "datetime")]
        public DateTime SalFecha { get; set; }
        [Column("SAL_cantidad")]
        public int SalCantidad { get; set; }

        [ForeignKey(nameof(SalIdProducto))]
        [InverseProperty(nameof(Producto.Salida))]
        public virtual Producto SalIdProductoNavigation { get; set; }
    }
}
