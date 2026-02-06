using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        ClienteResponseDTO Cadastrar(ClienteRequestDTO request);

        ClienteResponseDTO Alterar(int id, ClienteRequestDTO request);

        ClienteResponseDTO Excluir(int id);

        List<ClienteResponseDTO> Consultar();

        ClienteResponseDTO ConsultarPorId(int id);
    }
}
