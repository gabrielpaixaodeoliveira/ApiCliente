using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Repositories;
using ApiCliente.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiCliente.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public override void Add(Cliente cliente)
        {
            if (ClienteDuplicado(cliente))
                throw new ArgumentException("Já existe um cliente com o cpf informado");
            else
                _clienteRepository.Add(cliente);
        }

        public override void Update(Cliente cliente)
        {
            var clienteBase = _clienteRepository.GetById(cliente.IdCliente);

            if (clienteBase == null)
                throw new ArgumentException("Cliente não encontrado");
            else
            {
                clienteBase.AtualizaCliente(cliente);
                _clienteRepository.Update(clienteBase);
            }
        }

        public IEnumerable<Cliente> GetAllComInclude()
        {
            return _clienteRepository.GetAllComInclude();

        }

        public Cliente GetByIdComInclude(int IdCliente)
        {
            return _clienteRepository.GetByIdComInclude(IdCliente);

        }

        public void Remove(int IdCliente)
        {
            var clienteBase = _clienteRepository.GetById(IdCliente);

            if (clienteBase == null)
                throw new ArgumentException("Cliente não encontrado");
            else
                _clienteRepository.Remove(clienteBase);
        }

        private bool ClienteDuplicado(Cliente cliente)
        {
           return _clienteRepository.GetBy(x => x.Cpf == cliente.Cpf && x.IdCliente != cliente.IdCliente).Any();

        }
    }
}
