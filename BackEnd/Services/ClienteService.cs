using BackEnd.Domains.IRepositories;
using BackEnd.Domains.IServices;
using BackEnd.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task CreateCliente(Cliente cliente)
        {
            await _clienteRepository.CreateCliente(cliente);
        }

        public async Task EditCliente(Cliente cliente)
        {
            await _clienteRepository.EditCliente(cliente);
        }

        public async Task<List<Cliente>> GetListaClientes()
        {
           return await _clienteRepository.GetListaClientes();
        }

    }
}
