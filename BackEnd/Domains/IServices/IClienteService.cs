using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.IServices
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetListaClientes();
        Task CreateCliente(Cliente cliente);
        Task EditCliente(Cliente cliente);
    }
}
