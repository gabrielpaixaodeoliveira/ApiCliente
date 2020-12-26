using System.Collections.Generic;
using ApiCliente.Domain.Entities;

namespace ApiCliente.Domain.Interfaces.Services
{
    public interface IEnderecoService : IServiceBase<Endereco>
    {
        void Remove(int IdCliente);
    }
}
