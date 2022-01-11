using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.IServices
{
    public interface IFacturaService
    {
        Task<List<Factura>> GetListaFacturas();
        Task<int> CreateFactura(Factura factura);
        Task CreateDetalleFacturas(List<DetalleFactura> detalleFacturas);
    }
}
