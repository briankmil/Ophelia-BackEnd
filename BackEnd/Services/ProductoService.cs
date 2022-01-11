using BackEnd.Domains.IRepositories;
using BackEnd.Domains.IServices;
using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        public ProductoService(IProductoRepository productoRepository)
        {
            this._productoRepository = productoRepository;
        }

        public async Task CreateEntrada(Entrada entrada)
        {
            await _productoRepository.CreateEntrada(entrada);
        }

        public async Task CreateProducto(Producto producto)
        {
            await _productoRepository.CreateProducto(producto);
        }

        public async Task EditProducto(Producto producto)
        {
            await _productoRepository.EditProducto(producto);
        }

        public async Task<List<Producto>> GetListaProductos()
        {
            return await _productoRepository.GetListaProductos();
        }
    }
}
