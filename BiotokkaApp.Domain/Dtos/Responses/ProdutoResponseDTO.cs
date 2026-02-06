using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Responses
{
    public record ProdutoResponseDTO
    (
        int Id,
        string Nome,
        int CategoriaId,
        decimal Custo,
        decimal PrecoVenda,
        DateTime DataCadastro

    );
}
