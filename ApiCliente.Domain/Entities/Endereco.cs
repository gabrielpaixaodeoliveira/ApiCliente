using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        public virtual Cliente Cliente { get; set; }

    }
}
