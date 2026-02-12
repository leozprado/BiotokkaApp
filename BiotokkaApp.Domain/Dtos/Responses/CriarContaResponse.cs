using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Responses
{
    public record CriarContaResponse
   (
        int Id,
        string Nome,
        string Email,
        DateTime DataCriacao
        );
}
