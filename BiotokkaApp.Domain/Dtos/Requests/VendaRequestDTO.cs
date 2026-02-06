using BiotokkaApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Requests
{
    public record VendaRequestDTO
   (
        int ClienteId,
        int ProdutoId,
        int Quantidade,
        decimal PrecoUnitario,            
        FormaPagamento FormaPagamento,
        string? Observacoes
    );
}
