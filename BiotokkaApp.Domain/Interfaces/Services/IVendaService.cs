using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Interfaces.Services
{
    public interface IVendaService
    {
        VendaResponseDTO Criar(VendaRequestDTO request);

        VendaResponseDTO Atualizar(int id, VendaRequestDTO request);

        VendaResponseDTO Excluir(int id);

        List<VendaResponseDTO> ObterTodos();

        List<VendaResponseDTO> ObterPorDatas(DateTime dataInicio, DateTime dataFim);

        List<VendaResponseDTO> ObterPorCliente(int clienteId);

        List<VendaResponseDTO> ObterPorProduto(int produtoId);

        VendaResponseDTO ObterPorId(int id);
    }
}
