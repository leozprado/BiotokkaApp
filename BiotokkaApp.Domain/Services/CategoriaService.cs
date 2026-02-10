using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Dtos.Responses;
using BiotokkaApp.Domain.Entities;
using BiotokkaApp.Domain.Interfaces.Repositories;
using BiotokkaApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Services
{
           public class CategoriaService : ICategoriaService
        {
            private readonly ICategoriaRepository _categoriaRepository;

            public CategoriaService(ICategoriaRepository categoriaRepository)
            {
                _categoriaRepository = categoriaRepository;
            }

            public CategoriaResponseDTO Cadastrar(CategoriaRequestDTO categoriaRequest)
            {
                var categoria = new Categoria
                {
                    Nome = categoriaRequest.Nome,
                    Descricao = categoriaRequest.Descricao
                };

                _categoriaRepository.Add(categoria);

                return MapToResponse(categoria);
            }

            public CategoriaResponseDTO Atualizar(int id, CategoriaRequestDTO categoriaRequest)
            {
                var categoria = _categoriaRepository.GetById(id);

                if (categoria == null)
                {
                    throw new Exception($"Categoria com ID {id} não encontrada.");
                }

                categoria.Nome = categoriaRequest.Nome;
                categoria.Descricao = categoriaRequest.Descricao;

                _categoriaRepository.Update(categoria);

                return MapToResponse(categoria);
            }

            public CategoriaResponseDTO Excluir(int id)
            {
                var categoria = _categoriaRepository.GetById(id);

                if (categoria == null)
                {
                    throw new Exception($"Categoria com ID {id} não encontrada.");
                }

                _categoriaRepository.Delete(categoria);

                return MapToResponse(categoria);
            }

            public CategoriaResponseDTO ObterPorId(int id)
            {
                var categoria = _categoriaRepository.GetById(id);

                if (categoria == null)
                {
                    throw new Exception($"Categoria com ID {id} não encontrada.");
                }

                return MapToResponse(categoria);
            }

            public List<CategoriaResponseDTO> ObterTodos()
            {
                var categorias = _categoriaRepository.GetAll();

                return categorias.Select(c => MapToResponse(c)).ToList();
            }

            private CategoriaResponseDTO MapToResponse(Categoria categoria)
            {
                return new CategoriaResponseDTO(
                    Id: categoria.Id,
                    Nome: categoria.Nome,
                    DataCadastro: DateTime.UtcNow
                );
            }
        }
    }

