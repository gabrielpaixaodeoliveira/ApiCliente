﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiCliente.Domain.DTO;
using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace ApiCliente.Test.Domain
{
    public class ClienteServiceTest
    {
        Mock<IClienteService> mockService;
        List<Cliente> lista;

        public ClienteServiceTest()
        {
            lista = new List<Cliente>()
            {
                new Cliente(new ClienteEntradaDTO(){Nome = "Gabriel", Cpf= "13180202718",DtNascimento= Convert.ToDateTime("1988-12-16") }),
                new Cliente(new ClienteEntradaDTO() { Nome = "TESTE", Cpf = "87380202718", DtNascimento = Convert.ToDateTime("1988-11-01") })
            };
            mockService = new Mock<IClienteService>();
            mockService.Setup(x => x.GetByIdComInclude(It.IsAny<int>()))
                      .Returns((int i) => lista.Single(p => p.IdCliente == i));

            mockService.Setup(x => x.GetAllComInclude())
                      .Returns(lista);

        }

        [Fact]
        public void Obter_Cliente_Deve_Funcionar()
        {
            var clienteExiste = mockService.Object.GetAllComInclude();
            Assert.True(clienteExiste.Count() > 0);
        }
        


    }
}
