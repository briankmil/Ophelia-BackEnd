using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Domains.Models
{
    [Table("FACTURA")]
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        [Key]
        [Column("FAC_id")]
        public int FacId { get; set; }
        [Column("FAC_idCliente")]
        public int FacIdCliente { get; set; }
        [Column("FAC_fecha", TypeName = "datetime")]
        public DateTime FacFecha { get; set; }
        [Column("FAC_total", TypeName = "decimal(18, 0)")]
        public decimal FacTotal { get; set; }

        [ForeignKey(nameof(FacIdCliente))]
        [InverseProperty(nameof(Cliente.Facturas))]
        public virtual Cliente FacIdClienteNavigation { get; set; }
        [InverseProperty(nameof(DetalleFactura.DetfacIdFacturaNavigation))]
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
