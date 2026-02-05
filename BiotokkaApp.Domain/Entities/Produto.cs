using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public decimal Custo { get; set; }
        public decimal PrecoVenda { get; set; }            
        public DateTime DataCadastro { get; set; } = DateTime.Now;


        public Categoria Categoria { get; set; } = null!;
        public ICollection<Venda> Vendas { get; set; } = new List<Venda>();
    }
}
