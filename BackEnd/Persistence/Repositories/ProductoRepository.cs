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
    public class ProductoRepository : IProductoRepository
    {
        private readonly OpheliaDbContext _context;
        public ProductoRepository(OpheliaDbContext context)
        {
            _context = context;
        }

        public Task<List<Producto>> GetListaProductos()
        {
           return _context.Productos.ToListAsync();
        }
    }
}
