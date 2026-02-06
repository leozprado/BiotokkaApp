using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Requests
{
    public record ProdutoRequestDTO
    (
        string Nome,
        int CategoriaId,
        decimal Custo,
        decimal PrecoVenda
        );
}
