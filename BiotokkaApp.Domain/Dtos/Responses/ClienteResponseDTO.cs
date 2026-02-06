using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Responses
{
    public record ClienteResponseDTO
   (
        int Id,
        string Nome,
        string Email,
        string Telefone,
        DateTime DataCadastro,
        DateTime DataNascimento,
        string Cpf,
        string Endereco,
        List<VendaResponseDTO> Vendas

   );
}
