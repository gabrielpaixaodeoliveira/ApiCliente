using ApiCliente.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiCliente.Domain.DTO
{
    public class EnderecoEntradaDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(maximumLength: 50, ErrorMessage = "O campo {0} é obrigatório e deve ter entre {2} e {1} caracteres.", MinimumLength = 5)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(maximumLength: 40, ErrorMessage = "O campo {0} é obrigatório e deve ter entre {2} e {1} caracteres.", MinimumLength = 5)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(maximumLength: 40, ErrorMessage = "O campo {0} é obrigatório e deve ter entre {2} e {1} caracteres.", MinimumLength = 5)]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(maximumLength: 40, ErrorMessage = "O campo {0} é obrigatório e deve ter entre {2} e {1} caracteres.", MinimumLength = 5)]
        public string Cidade { get; set; }
    }
}
