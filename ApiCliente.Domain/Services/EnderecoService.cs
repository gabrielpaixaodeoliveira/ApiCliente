using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Repositories;
using ApiCliente.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiCliente.Domain.Services
{
    public class EnderecoService : ServiceBase<Endereco>, IEnderecoService
    {
        private readonly IRepositoryBase<Endereco> _enderecoRepository;
        private readonly IClienteRepository _clienteRepository;

        public EnderecoService(IRepositoryBase<Endereco> enderecoRepository, IClienteRepository clienteRepository)
            : base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
            _clienteRepository = clienteRepository;
        }

        public override void Add(Endereco endereco)
        {
            var cliente = _clienteRepository.GetById(endereco.IdCliente);

            if (cliente == null)
                throw new ArgumentException("Cliente não existe");

            _enderecoRepository.Add(endereco);
        }

        public override void Update(Endereco endereco)
        {
            var cliente = _clienteRepository.GetById(endereco.IdCliente);

            if (cliente == null)
                throw new ArgumentException("Cliente não existe");

            var enderecoBase = _enderecoRepository.GetById(endereco.IdEndereco);

            if (enderecoBase == null)
                throw new ArgumentException("Endereco não encontrado");
            else
            {
                enderecoBase.AtualizaEndereco(endereco);
                _enderecoRepository.Update(enderecoBase);
            }
        }
        public void Remove(int IdEndereco)
        {
            var enderecoBase = _enderecoRepository.GetById(IdEndereco);

            if (enderecoBase == null)
                throw new ArgumentException("Endereco não encontrado");
            else
                _enderecoRepository.Remove(enderecoBase);
        }

    }
}
