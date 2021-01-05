
using ApiCliente.Domain.DTO;
using ApiCliente.Domain.Entities;
using ApiCliente.Domain.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ApiCliente.Test.Repository
{
    public class ClienteRepositoryTest
    {
        List<Cliente> lista;
        
        Mock<IClienteRepository> mockRepository;
        public ClienteRepositoryTest()
        {
            lista = new List<Cliente>()
            {
                new Cliente(new ClienteEntradaDTO(){Nome = "Gabriel", Cpf= "13180202718",DtNascimento= Convert.ToDateTime("1988-12-16") }),
                new Cliente(new ClienteEntradaDTO() { Nome = "TESTE", Cpf = "87380202718", DtNascimento = Convert.ToDateTime("1988-11-01") }) 
            };
            mockRepository = new Mock<IClienteRepository>();
            mockRepository.Setup(x => x.GetById(It.IsAny<int>()))
                      .Returns((int i) => lista.Single(p => p.IdCliente == i));

            mockRepository.Setup(x => x.GetAll())
                      .Returns(lista);
        }


        [Fact]
        public void Obter_Cliente_Deve_Funcionar()
        {
            var clienteExiste = mockRepository.Object.GetAll();
            Assert.True(clienteExiste.Count() > 0);
        }


    }
}
