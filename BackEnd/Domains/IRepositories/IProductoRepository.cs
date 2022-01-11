using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.IRepositories
{
    public interface IProductoRepository
    {
        Task<List<Producto>> GetListaProductos();
        Task CreateEntrada(Entrada entrada);
        Task CreateProducto(Producto producto);
        Task EditProducto(Producto producto);

    }
}
