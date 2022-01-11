using BackEnd.Domains.IRepositories;
using BackEnd.Domains.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly OpheliaDbContext _context;
        public FacturaRepository(OpheliaDbContext context)
        {
            _context = context;
        }

        public async Task CreateDetalleFacturas(List<DetalleFactura> detalleFacturas)
        {
            foreach (DetalleFactura item in detalleFacturas)
            {
                _context.Add(item);
                _context.Add(new Salidum
                {
                    SalCantidad = item.DetfacCantidad.Value,
                    SalFecha = DateTime.Now,
                    SalIdProducto = item.DetfacIdProducto.Value
                });
            }
            await _context.SaveChangesAsync();

        }

        public async Task<int> CreateFactura(Factura factura)
        {
             _context.Add(factura);
            await _context.SaveChangesAsync();
            return factura.FacId;
        }

        public async Task<List<Factura>> GetListaFacturas()
        {
            return await _context.Facturas.ToListAsync();
        }
    }
}
