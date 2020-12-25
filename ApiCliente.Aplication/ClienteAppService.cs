using ApiCliente.Domain.DTO;
using ApiCliente.Aplication.Interface;
using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace ApiCliente.Aplication
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IEnumerable<ClienteSaidaDTO> GetAll()
        {
            List<ClienteSaidaDTO> lista = _clienteService.GetAll().Select(cli => (ClienteSaidaDTO)cli).ToList();;
            return lista;
        }
        public void Add(ClienteEntradaDTO cli)
        {
            _clienteService.Add(new Cliente(cli));            
        }


        public void Update(ClienteEntradaDTO cli, int IdCliente)
        {
            _clienteService.Update(new Cliente(cli, IdCliente));
        }
    }
}
