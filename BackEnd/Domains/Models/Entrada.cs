using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Domains.Models
{
    [Table("ENTRADA")]
    public partial class Entrada
    {
        [Key]
        [Column("ENT_id")]
        public int EntId { get; set; }
        [Column("ENT_idProducto")]
        public int EntIdProducto { get; set; }
        [Column("ENT_fecha", TypeName = "datetime")]
        public DateTime EntFecha { get; set; }
        [Column("ENT_cantidad")]
        public int EntCantidad { get; set; }

        [ForeignKey(nameof(EntIdProducto))]
        [InverseProperty(nameof(Producto.Entrada))]
        public virtual Producto EntIdProductoNavigation { get; set; }
    }
}
