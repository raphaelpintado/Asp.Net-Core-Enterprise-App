﻿using Microsoft.EntityFrameworkCore;
using NSE.Cliente.API.Models;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Cliente.API.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _context;

        public ClienteRepository(ClienteContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Models.Cliente>> ObterTodos()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public Task<Models.Cliente> ObterPorCpf(string cpf)
        {
            return _context.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public void Adicionar(Models.Cliente cliente)
        {
            _context.Clientes.Add(cliente);
        }

        public void Dispose()
        {
            _context.Dispose();
        }                
    }
}
