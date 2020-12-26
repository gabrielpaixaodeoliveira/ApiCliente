using ApiCliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiCliente.Domain.DTO
{
    public class EnderecoSaidaDTO
    {
        public int IdEndereco { get; set; }        
        public int IdCliente { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }





        public static explicit operator EnderecoSaidaDTO(Endereco entidade)
        {
            return new EnderecoSaidaDTO()
            {
                IdEndereco = entidade.IdEndereco,
                IdCliente = entidade.IdCliente,
                Logradouro = entidade.Logradouro,
                Bairro  = entidade.Bairro,
                Estado = entidade.Estado,
                Cidade = entidade.Cidade

            };
        }
    }
}
