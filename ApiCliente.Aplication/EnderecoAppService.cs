using ApiCliente.Domain.DTO;
using ApiCliente.Aplication.Interface;
using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ApiCliente.Aplication
{
    public class EnderecoAppService : AppServiceBase<Endereco>, IEnderecoAppService
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoAppService(IEnderecoService enderecoService)
            : base(enderecoService)
        {
            _enderecoService = enderecoService;
        }

        public IEnumerable<EnderecoSaidaDTO> GetAll()
        {

            var enderecos = _enderecoService.GetAll();

            if (enderecos == null)
                return null;
            else
                return enderecos.Select(end => (EnderecoSaidaDTO)end).ToList();
        }
        public EnderecoSaidaDTO GetById(int IdEndereco)
        {

            var endereco = _enderecoService.GetById(IdEndereco);

            if (endereco == null)
                return null;
            else
                return (EnderecoSaidaDTO)endereco;
        }

        public EnderecoSaidaDTO Add(EnderecoEntradaDTO end)
        {
            var endereco = new Endereco(end);
            _enderecoService.Add(endereco);
            return (EnderecoSaidaDTO)endereco;
        }


        public void Update(EnderecoEntradaDTO end, int IdEndereco)
        {
            _enderecoService.Update(new Endereco(end, IdEndereco));
        }
        public void Remove(int IdEndereco)
        {
            _enderecoService.Remove(IdEndereco);
        }
    }
}
