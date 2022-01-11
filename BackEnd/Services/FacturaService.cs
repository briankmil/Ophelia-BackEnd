using BackEnd.Domains.IRepositories;
using BackEnd.Domains.IServices;
using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class FacturaService : IFacturaService
    {
        private readonly IFacturaRepository _facturaRepository;
        public FacturaService(IFacturaRepository facturaRepository)
        {
            this._facturaRepository = facturaRepository;
        }

        public async Task CreateDetalleFacturas(List<DetalleFactura> detalleFacturas)
        {
            await _facturaRepository.CreateDetalleFacturas(detalleFacturas);
        }

        public async Task<int> CreateFactura(Factura factura)
        {
            return await _facturaRepository.CreateFactura(factura);
        }

        public async Task<List<Factura>> GetListaFacturas()
        {
            return await _facturaRepository.GetListaFacturas();
        }
    }
}
