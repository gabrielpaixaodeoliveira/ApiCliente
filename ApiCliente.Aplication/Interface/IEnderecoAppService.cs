using ApiCliente.Domain.DTO;
using ApiCliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCliente.Aplication.Interface
{
    public interface IEnderecoAppService
    {
        IEnumerable<EnderecoSaidaDTO> GetAll();
        EnderecoSaidaDTO GetById(int IdEndereco);
        EnderecoSaidaDTO Add(EnderecoEntradaDTO endereco);
        void Update(EnderecoEntradaDTO endereco, int IdEndereco);
        void Remove(int IdEndereco);
    }
}
