using System.ComponentModel.DataAnnotations;
using ApiCliente.Domain.DTO;

namespace ApiCliente.Domain.Entities
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; private set; }
        public int IdCliente { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public Endereco()
        {
        }

        public Endereco(EnderecoEntradaDTO enderecoEntrada, int id = 0)
        {
            IdCliente = enderecoEntrada.IdCliente;
            Logradouro = enderecoEntrada.Logradouro;
            Bairro = enderecoEntrada.Bairro;
            Estado = enderecoEntrada.Estado;
            Cidade = enderecoEntrada.Cidade;

            if (id > 0)
                IdEndereco = id;
        }
        public void AtualizaEndereco(Endereco enderecoAtualizado)
        {
            Cidade = enderecoAtualizado.Cidade;
            Bairro = enderecoAtualizado.Bairro;
            Estado = enderecoAtualizado.Estado;
            Logradouro = enderecoAtualizado.Logradouro;
        }


    }
}
