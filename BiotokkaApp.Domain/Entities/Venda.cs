using BiotokkaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; } = DateTime.UtcNow;
        public FormaPagamento FormaPagamento { get; set; }
        public string? Observacoes { get; set; }

        #region Relacionamentos

        public Cliente Cliente { get; set; } = null!;
        public Produto Produto { get; set; } = null!;

        #endregion
    }
}
