using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Responses
{
    public record VendaResponseDTO
   (
        int Id,
        int ClienteId,
        int ProdutoId,
        int Quantidade,
        decimal PrecoUnitario,
        decimal ValorTotal,
        DateTime DataVenda,
        string FormaPagamento,
        string? Observacoes


   );
}
