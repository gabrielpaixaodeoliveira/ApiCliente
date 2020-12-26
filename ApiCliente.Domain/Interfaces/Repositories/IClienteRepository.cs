using System.Collections.Generic;
using ApiCliente.Domain.Entities;

namespace ApiCliente.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        IEnumerable<Cliente> GetAllComInclude();
        Cliente GetByIdComInclude(int IdCliente);
           
    }
}
