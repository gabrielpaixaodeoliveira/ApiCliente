using ApiCliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiCliente.Domain.DTO
{
    public class ClienteSaidaDTO
    {
        public int Id { get; set; }


        public string Nome { get; set; }

        public string Cpf { get; set; }

        [JsonIgnore]
        public DateTime DtNascimento { get; set; }
        

        private int _idade = 0;

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
                Id = entidade.IdCliente,
                Cpf = entidade.Cpf,
                DtNascimento = entidade.DtNascimento,
                Nome = entidade.Nome
            };
        }
    }
}
