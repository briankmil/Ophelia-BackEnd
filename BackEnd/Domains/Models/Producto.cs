using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Domains.Models
{
    [Table("PRODUCTO")]
    public partial class Producto
    {
        public Producto()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
            Entrada = new HashSet<Entrada>();
            Salida = new HashSet<Salidum>();
        }

        [Key]
        [Column("PRO_id")]
        public int ProId { get; set; }
        [Required]
        [Column("PRO_nombre")]
        [StringLength(100)]
        public string ProNombre { get; set; }
        [Column("PRO_valorVentaPublico", TypeName = "decimal(18, 0)")]
        public decimal ProValorVentaPublico { get; set; }
        [Column("PRO_inventario")]
        public int? ProInventario { get; set; }

        [InverseProperty(nameof(DetalleFactura.DetfacIdProductoNavigation))]
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
        [InverseProperty(nameof(Models.Entrada.EntIdProductoNavigation))]
        public virtual ICollection<Entrada> Entrada { get; set; }
        [InverseProperty(nameof(Salidum.SalIdProductoNavigation))]
        public virtual ICollection<Salidum> Salida { get; set; }
    }
}
