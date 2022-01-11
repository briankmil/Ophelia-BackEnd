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

        public async Task CreateEntrada(Entrada entrada)
        {
            entrada.EntFecha = DateTime.Now;
            _context.Add(entrada);
            await _context.SaveChangesAsync();
        }

        public async Task CreateProducto(Producto producto)
        {
            _context.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EditProducto(Producto producto)
        {
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Producto>> GetListaProductos()
        {
           return await _context.Productos.ToListAsync();
        }
    }
}
