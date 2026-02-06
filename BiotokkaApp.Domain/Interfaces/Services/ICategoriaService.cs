using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        CategoriaResponseDTO Cadastrar(CategoriaRequestDTO categoriaRequest);

        CategoriaResponseDTO Atualizar(int id, CategoriaRequestDTO categoriaRequest);

        CategoriaResponseDTO Excluir(int id);

        CategoriaResponseDTO ObterPorId(int id);

        List<CategoriaResponseDTO> ObterTodos();
    }
}
