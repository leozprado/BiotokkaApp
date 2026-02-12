using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Requests
{
    public record CriarContaRequest
    (
        string nome,
        string email,
        string senha
        );

    
}
