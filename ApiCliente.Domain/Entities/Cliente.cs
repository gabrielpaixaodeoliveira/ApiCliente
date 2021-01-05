using ApiCliente.Domain.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApiCliente.Domain.Entities
{
    /*Considere que o domínio é rico e as especificações de negócio são:
 Cliente deve conter ao menos um identificador, nome, cpf e idade;
 Nome do cliente deve ser obrigatório e ter no máximo 30 caracteres;
 Cpf do cliente deve ser obrigatório e válido;
 Data de nascimento do cliente deve ser obrigatória;*/

    public class Cliente
    {
        Regex reg = new Regex(@"[^0-9]");
        public Cliente()
        {
        }

        public Cliente(ClienteEntradaDTO clienteEntrada, int id = 0)
        {
            Nome = clienteEntrada.Nome;
            Cpf = reg.Replace(clienteEntrada.Cpf, string.Empty); 
            DtNascimento = clienteEntrada.DtNascimento;
            if (id > 0)
                IdCliente = id;
        }

        public void AtualizaCliente(Cliente clienteAtualizado)
        {
            Cpf = clienteAtualizado.Cpf;
            DtNascimento = clienteAtualizado.DtNascimento;
            Nome = clienteAtualizado.Nome;
        }

        [Key]
        public int IdCliente { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }

        public DateTime DtNascimento { get; private set; }

        public virtual List<Endereco> Endereco { get; private set; }


    }
}
