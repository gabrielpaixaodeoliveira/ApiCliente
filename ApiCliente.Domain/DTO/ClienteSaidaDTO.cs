using ApiCliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace ApiCliente.Domain.DTO
{
    public class ClienteSaidaDTO
    {
        public int IdCliente { get; set; }


        public string Nome { get; set; }

        public string Cpf { get; set; }
        public List<EnderecoSaidaDTO> Endereco { get; set; }


        private int _idade = 0;


        [JsonIgnore]
        public DateTime DtNascimento { get; set; }


        public int Idade
        {
            get
            {
                if (this.DtNascimento != null)
                {
                    _idade = (DateTime.Now.DayOfYear > this.DtNascimento.DayOfYear) ? DateTime.Now.Year - this.DtNascimento.Year : (DateTime.Now.Year - this.DtNascimento.Year) - 1;

                }
                return _idade;
            }
            set
            {
                _idade = value;
            }
        }


        public static explicit operator ClienteSaidaDTO(Cliente entidade)
        {
            return new ClienteSaidaDTO()
            {
                IdCliente = entidade.IdCliente,
                Cpf = entidade.Cpf,
                DtNascimento = entidade.DtNascimento,
                Nome = entidade.Nome,
                Endereco =  entidade.Endereco.Select(end => (EnderecoSaidaDTO)end).ToList()
            };
        }
    }
}
