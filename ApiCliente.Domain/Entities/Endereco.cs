using System;
using System.Collections.Generic;
using System.Text;

namespace ApiCliente.Domain.Entities
{
    public class Endereco
    {
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

    }
}
