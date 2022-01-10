using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Domains.Models
{
    [Table("DETALLE_FACTURA")]
    public partial class DetalleFactura
    {
        [Key]
        [Column("DETFAC_id")]
        public int DetfacId { get; set; }
        [Column("DETFAC_idFactura")]
        public int? DetfacIdFactura { get; set; }
        [Column("DETFAC_idProducto")]
        public int? DetfacIdProducto { get; set; }
        [Column("DETFAC_valorFacturado", TypeName = "decimal(18, 0)")]
        public decimal? DetfacValorFacturado { get; set; }
        [Column("DETFAC_cantidad")]
        public int? DetfacCantidad { get; set; }
        [Column("DETFAC_valorTotalFacturado", TypeName = "decimal(18, 0)")]
        public decimal? DetfacValorTotalFacturado { get; set; }

        [ForeignKey(nameof(DetfacIdFactura))]
        [InverseProperty(nameof(Factura.DetalleFacturas))]
        public virtual Factura DetfacIdFacturaNavigation { get; set; }
        [ForeignKey(nameof(DetfacIdProducto))]
        [InverseProperty(nameof(Producto.DetalleFacturas))]
        public virtual Producto DetfacIdProductoNavigation { get; set; }
    }
}
