using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Requests
{
    public record ClienteRequestDTO(
      string NomeCompleto,
      string Cpf,
      DateTime DataNascimento,
      string Endereco,
      string Telefone,
      string Email
    );
    
    
}
