﻿using System.Collections.Generic;
using ApiCliente.Domain.Entities;

namespace ApiCliente.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        void Remove(int IdCliente);
        IEnumerable<Cliente> GetAllComInclude();
        Cliente GetByIdComInclude(int IdCliente);
    }
}
