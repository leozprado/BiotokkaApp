using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Responses
{
    public record CategoriaResponseDTO
    (
        int Id,
        string Nome,
        DateTime DataCadastro
    );
    
}
