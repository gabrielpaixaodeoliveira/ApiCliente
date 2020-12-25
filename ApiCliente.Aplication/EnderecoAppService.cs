using ApiCliente.Domain.DTO;
using ApiCliente.Aplication.Interface;
using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ApiCliente.Aplication
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IServiceBase<Endereco> _enderecoService;

        public EnderecoAppService(IServiceBase<Endereco> enderecoService)
        {
            _enderecoService = enderecoService;
        }

        public IEnumerable<Endereco> GetAll()
        {
            return _enderecoService.GetAll();
        }
        public void Add(Endereco endereco)
        {
            _enderecoService.Add(endereco);            
        }


        public void Update(Endereco endereco, int IdEndereco)
        {
            endereco.IdEndereco = IdEndereco;
            _enderecoService.Update(endereco);
        }
    }
}
