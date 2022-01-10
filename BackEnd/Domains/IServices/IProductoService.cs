using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.IServices
{
    public interface IProductoService
    {
        Task<List<Producto>> GetListaProductos();
    }
}
