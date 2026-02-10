using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Dtos.Responses;
using BiotokkaApp.Domain.Entities;
using BiotokkaApp.Domain.Interfaces.Repositories;
using BiotokkaApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiotokkaApp.Domain.Services
{
    public class VendaService(IVendaRepository VendaRepository) : IVendaService
    {
          

        public VendaResponseDTO Cadastrar(VendaRequestDTO request)
        {
            var venda = new Venda
            {
                ClienteId = request.ClienteId,
                ProdutoId = request.ProdutoId,
                Quantidade = request.Quantidade,
                PrecoUnitario = request.PrecoUnitario,
                ValorTotal = request.Quantidade * request.PrecoUnitario,
                DataVenda = DateTime.UtcNow,
                FormaPagamento = request.FormaPagamento,
                Observacoes = request.Observacoes
            };

            VendaRepository.Add(venda);

            return VendaResponseDTO(venda);
        }

        public VendaResponseDTO Atualizar(int id, VendaRequestDTO request)
        {
            var venda = VendaRepository.GetById(id);

            if (venda == null)
            {
                throw new Exception($"Venda com ID {id} não encontrada.");
            }

            venda.ClienteId = request.ClienteId;
            venda.ProdutoId = request.ProdutoId;
            venda.Quantidade = request.Quantidade;
            venda.PrecoUnitario = request.PrecoUnitario;
            venda.ValorTotal = request.Quantidade * request.PrecoUnitario;
            venda.FormaPagamento = request.FormaPagamento;
            venda.Observacoes = request.Observacoes;

            VendaRepository.Update(venda);

            return VendaResponseDTO(venda);
        }

        public VendaResponseDTO Excluir(int id)
        {
            var venda = VendaRepository.GetById(id);

            if (venda == null)
            {
                throw new Exception($"Venda com ID {id} não encontrada.");
            }

            VendaRepository.Delete(venda);

            return VendaResponseDTO(venda);
        }

        public List<VendaResponseDTO> ObterTodos()
        {
            var vendas = VendaRepository.GetAll();

            return vendas.Select(v => VendaResponseDTO(v)).ToList();
        }

        public List<VendaResponseDTO> ObterPorDatas(DateTime dataInicio, DateTime dataFim)
        {
            var vendas = VendaRepository.GetVendasByDatas(dataInicio, dataFim);

            return vendas.Select(v => VendaResponseDTO(v)).ToList();
        }

        public List<VendaResponseDTO> ObterPorCliente(int clienteId)
        {
            var vendas = VendaRepository.GetVendasByCliente(clienteId);

            return vendas.Select(v => VendaResponseDTO(v)).ToList();
        }

        public List<VendaResponseDTO> ObterPorProduto(int produtoId)
        {
            var vendas = VendaRepository.GetVendasByProduto(produtoId);

            return vendas.Select(v => VendaResponseDTO(v)).ToList();
        }

        public VendaResponseDTO ObterPorId(int id)
        {
            var venda = VendaRepository.GetById(id);

            if (venda == null)
            {
                throw new Exception($"Venda com ID {id} não encontrada.");
            }

            return VendaResponseDTO(venda);
        }

        private VendaResponseDTO VendaResponseDTO(Venda venda)
        {
            return new VendaResponseDTO(
                Id: venda.Id,
                ClienteId: venda.ClienteId,
                ProdutoId: venda.ProdutoId,
                Quantidade: venda.Quantidade,
                PrecoUnitario: venda.PrecoUnitario,
                ValorTotal: venda.ValorTotal,
                DataVenda: venda.DataVenda,
                FormaPagamento: venda.FormaPagamento.ToString(),
                Observacoes: venda.Observacoes
            );
        }
    }
}
