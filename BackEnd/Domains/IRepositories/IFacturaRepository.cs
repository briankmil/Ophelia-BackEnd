using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.IRepositories
{
    public interface IFacturaRepository
    {
        Task<List<Factura>> GetListaFacturas();
        Task CreateDetalleFacturas(List<DetalleFactura> detalleFacturas);
        Task<int> CreateFactura(Factura factura);

    }
}
