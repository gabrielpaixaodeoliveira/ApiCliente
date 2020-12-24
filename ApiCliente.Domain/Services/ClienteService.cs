using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Repositories;
using ApiCliente.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
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
    }
}
