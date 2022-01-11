using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domains.IRepositories
{
    public interface IClienteRepository
    {
        Task CreateCliente(Cliente cliente);
        Task EditCliente(Cliente cliente);
        Task<List<Cliente>> GetListaClientes();

    }
}
