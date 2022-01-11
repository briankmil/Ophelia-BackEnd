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

        public Task CreateDetalleFacturas(List<DetalleFactura> detalleFacturas)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateFactura(Factura factura)
        {
            throw new NotImplementedException();
        }

        public Task<List<Factura>> GetListaFacturas()
        {
            throw new NotImplementedException();
        }
    }
}
