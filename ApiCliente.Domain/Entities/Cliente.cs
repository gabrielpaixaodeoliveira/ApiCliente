﻿using ApiCliente.Domain.DTO;
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

        [Key]
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public DateTime DtNascimento { get; set; }

        public virtual List<Endereco> Endereco { get; set; }


    }
}
