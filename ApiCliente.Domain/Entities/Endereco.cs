using System.ComponentModel.DataAnnotations;
using ApiCliente.Domain.DTO;

namespace ApiCliente.Domain.Entities
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; set; }
        public int IdCliente { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
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

    }
}
