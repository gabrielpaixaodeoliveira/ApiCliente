using ApiCliente.Domain.DTO;
using ApiCliente.Aplication.Interface;
using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ApiCliente.Aplication
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService     
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<ClienteSaidaDTO> GetAllComInclude()
        {
            return _clienteService.GetAllComInclude().Select(cli => (ClienteSaidaDTO)cli).ToList();
        }
        public ClienteSaidaDTO GetByIdComInclude(int IdCliente)
        {             
            return (ClienteSaidaDTO)_clienteService.GetByIdComInclude(IdCliente);
        }

        public ClienteSaidaDTO Add(ClienteEntradaDTO cli)
        {
            var cliente = new Cliente(cli);
            _clienteService.Add(cliente);
            return (ClienteSaidaDTO)cliente;
        }


        public void Update(ClienteEntradaDTO cli, int IdCliente)
        {
            _clienteService.Update(new Cliente(cli, IdCliente));
        }
        public void Remove(int IdCliente)
        {
            _clienteService.Remove(IdCliente);
        }
    }
}
