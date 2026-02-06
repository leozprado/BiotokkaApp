using BiotokkaApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Interfaces.Services
{
    public interface IprodutoService
    {
        ProdutoResponseDTO Criar (ProdutoResponseDTO produtoRequest);

        ProdutoResponseDTO Atualizar (int id, ProdutoResponseDTO produtoRequest);

        ProdutoResponseDTO Excluir (int id);

        ProdutoResponseDTO ObterPorId(int id);

        List<ProdutoResponseDTO> ObterTodos();
    }
}
