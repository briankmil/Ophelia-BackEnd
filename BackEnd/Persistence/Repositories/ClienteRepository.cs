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
    public class ClienteRepository : IClienteRepository
    {
        private readonly OpheliaDbContext _context;
        public ClienteRepository(OpheliaDbContext context)
        {
            _context = context;
        }

        public async Task CreateCliente(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task EditCliente(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Cliente>> GetListaClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

    }
}
