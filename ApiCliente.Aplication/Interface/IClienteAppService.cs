using ApiCliente.Domain.DTO;
using ApiCliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCliente.Aplication.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<ClienteSaidaDTO> GetAllComInclude();
        ClienteSaidaDTO GetByIdComInclude(int IdCliente);
        ClienteSaidaDTO Add(ClienteEntradaDTO cli);
        void Remove(int IdCliente);
        void Update(ClienteEntradaDTO cli, int IdCliente);
    }
}
