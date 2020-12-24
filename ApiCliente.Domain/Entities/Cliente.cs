using ApiCliente.Domain.DTO;
using System;

namespace ApiCliente.Domain.Entities
{
    /*Considere que o domínio é rico e as especificações de negócio são:
 Cliente deve conter ao menos um identificador, nome, cpf e idade;
 Nome do cliente deve ser obrigatório e ter no máximo 30 caracteres;
 Cpf do cliente deve ser obrigatório e válido;
 Data de nascimento do cliente deve ser obrigatória;*/

    public class Cliente
    {
        public Cliente()
        {
        }

        public Cliente(ClienteEntradaDTO clienteEntrada, int id = 0)
        {
            Nome = clienteEntrada.Nome;
            Cpf = clienteEntrada.Cpf;
            DtNascimento = clienteEntrada.DtNascimento;
            if (id > 0)
                IdCliente = id;
        }

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public DateTime DtNascimento { get; set; }


    }
}
