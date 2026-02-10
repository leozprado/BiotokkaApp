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
    public class ProdutoService(IProdutoRepository ProdutoRepository) : IprodutoService
    {
       
        public ProdutoResponseDTO Cadastrar(ProdutoRequestDTO produtoRequest)
        {
            var produto = new Produto
            {
                Nome = produtoRequest.Nome,
                CategoriaId = produtoRequest.CategoriaId,
                Custo = produtoRequest.Custo,
                PrecoVenda = produtoRequest.PrecoVenda,
                DataCadastro = DateTime.UtcNow
            };

            ProdutoRepository.Add(produto);

            return MapToResponse(produto);
        }

        public ProdutoResponseDTO Atualizar(int id, ProdutoRequestDTO produtoRequest)
        {
            var produto = ProdutoRepository.GetById(id);

            if (produto == null)
            {
                throw new Exception($"Produto com ID {id} não encontrado.");
            }

            produto.Nome = produtoRequest.Nome;
            produto.CategoriaId = produtoRequest.CategoriaId;
            produto.Custo = produtoRequest.Custo;
            produto.PrecoVenda = produtoRequest.PrecoVenda;

            ProdutoRepository.Update(produto);

            return MapToResponse(produto);
        }

        public ProdutoResponseDTO Excluir(int id)
        {
            var produto = ProdutoRepository.GetById(id);

            if (produto == null)
            {
                throw new Exception($"Produto com ID {id} não encontrado.");
            }

            ProdutoRepository.Delete(produto);

            return MapToResponse(produto);
        }

        public ProdutoResponseDTO ObterPorId(int id)
        {
            var produto = ProdutoRepository.GetById(id);

            if (produto == null)
            {
                throw new Exception($"Produto com ID {id} não encontrado.");
            }

            return MapToResponse(produto);
        }

        public List<ProdutoResponseDTO> ObterTodos()
        {
            var produtos = ProdutoRepository.GetAll();

            return produtos.Select(p => MapToResponse(p)).ToList();
        }

        private ProdutoResponseDTO MapToResponse(Produto produto)
        {
            return new ProdutoResponseDTO(
                Id: produto.Id,
                Nome: produto.Nome,
                CategoriaId: produto.CategoriaId,
                Custo: produto.Custo,
                PrecoVenda: produto.PrecoVenda,
                DataCadastro: produto.DataCadastro
            );
        }
    }
}
