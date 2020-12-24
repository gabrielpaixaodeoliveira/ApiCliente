using ApiCliente.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiCliente.Domain.DTO
{
    public class ClienteEntradaDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(maximumLength: 30, ErrorMessage = "O campo {0} é obrigatório e deve ter entre {2} e {1} caracteres.", MinimumLength = 5)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [CpfValidationAttribute(ErrorMessage = "Cpf invalido")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        [DateValidation(ErrorMessage = "A data de nascimento é inválida")]
        public DateTime DtNascimento { get; set; }
    }
}
