using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        public string Endereco { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime DataCadastro { get; set; } = DateTime.Now;

        

        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();


    }
}
