using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Domains.Models
{
    [Table("CLIENTE")]
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        [Key]
        [Column("CLI_id")]
        public int CliId { get; set; }
        [Required]
        [Column("CLI_tipoIdentificacion")]
        [StringLength(10)]
        public string CliTipoIdentificacion { get; set; }
        [Required]
        [Column("CLI_identificacion")]
        [StringLength(20)]
        public string CliIdentificacion { get; set; }
        [Required]
        [Column("CLI_nombres")]
        [StringLength(100)]
        public string CliNombres { get; set; }
        [Required]
        [Column("CLI_apellidos")]
        [StringLength(100)]
        public string CliApellidos { get; set; }
        [Column("CLI_fechaNacimiento", TypeName = "date")]
        public DateTime CliFechaNacimiento { get; set; }

        [InverseProperty(nameof(Factura.FacIdClienteNavigation))]
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
