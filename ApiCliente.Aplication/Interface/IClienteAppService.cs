using ApiCliente.Domain.DTO;
using ApiCliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCliente.Aplication.Interface
{
    public interface IClienteAppService
    {
        IEnumerable<ClienteSaidaDTO> GetAll();
        void Add(ClienteEntradaDTO cli);
        void Update(ClienteEntradaDTO cli);
    }
}
