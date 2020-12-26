using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Repositories;
using ApiCliente.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ApiCliente.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        ClienteContext Db;
        public ClienteRepository(ClienteContext db) : base(db)
        {
            Db = db;
        }

        public IEnumerable<Cliente> GetAllComInclude()
        {
          return  Db.Clientes.Include(p => p.Endereco).AsNoTracking();
        }
        public Cliente GetByIdComInclude(int IdCliente)
        {
            return Db.Clientes.Include(p => p.Endereco).AsNoTracking().FirstOrDefault(p => p.IdCliente == IdCliente);
        }
    }
}
