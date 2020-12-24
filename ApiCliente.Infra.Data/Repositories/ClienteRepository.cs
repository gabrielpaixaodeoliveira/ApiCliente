using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Repositories;
using ApiCliente.Infra.Data.Context;

namespace ApiCliente.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ClienteContext db) : base(db)
        {
        }
    }
}
