using ApiCliente.Domain.DTO;
using ApiCliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCliente.Aplication.Interface
{
    public interface IEnderecoAppService
    {
        IEnumerable<Endereco> GetAll();
        void Add(Endereco cli);
        void Update(Endereco cli, int IdCliente);
    }
}
