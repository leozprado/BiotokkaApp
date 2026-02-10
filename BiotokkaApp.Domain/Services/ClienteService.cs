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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public ClienteResponseDTO Cadastrar(ClienteRequestDTO request)
        {
            var cliente = new Cliente
            {
                NomeCompleto = request.NomeCompleto,
                Cpf = request.Cpf,
                DataNascimento = request.DataNascimento,
                Endereco = request.Endereco,
                Telefone = request.Telefone,
                Email = request.Email,
                DataCadastro = DateTime.UtcNow,              
            };

            _clienteRepository.Add(cliente);

            return MapearParaDTO(cliente);
        }

        public ClienteResponseDTO Alterar(int id, ClienteRequestDTO request)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
            {
                throw new Exception($"Cliente com ID {id} não encontrado.");
            }

            cliente.NomeCompleto = request.NomeCompleto;
            cliente.Cpf = request.Cpf;
            cliente.DataNascimento = request.DataNascimento;
            cliente.Endereco = request.Endereco;
            cliente.Telefone = request.Telefone;
            cliente.Email = request.Email;

            _clienteRepository.Update(cliente);

            return MapearParaDTO(cliente);
        }

        public ClienteResponseDTO Excluir(int id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
            {
                throw new Exception($"Cliente com ID {id} não encontrado.");
            }

            _clienteRepository.Delete(cliente);

            return MapearParaDTO(cliente);
        }

        public List<ClienteResponseDTO> ObterTodos()
        {
            var clientes = _clienteRepository.GetAll();

            return clientes.Select(c => MapearParaDTO(c)).ToList();
        }

        public ClienteResponseDTO ObterPorId(int id)
        {
            var cliente = _clienteRepository.GetById(id);

            if (cliente == null)
            {
                throw new Exception($"Cliente com ID {id} não encontrado.");
            }

            return MapearParaDTO(cliente);
        }

        private ClienteResponseDTO MapearParaDTO(Cliente cliente)
        {
            return new ClienteResponseDTO(
                Id: cliente.Id,
                Nome: cliente.NomeCompleto,
                Email: cliente.Email,
                Telefone: cliente.Telefone,
                DataCadastro: cliente.DataCadastro,
                DataNascimento: cliente.DataNascimento,
                Cpf: cliente.Cpf,
                Endereco: cliente.Endereco,
                Vendas: cliente.Vendas?.Select(v => new VendaResponseDTO(
                    Id: v.Id,
                    ClienteId: v.ClienteId,
                    ProdutoId: v.ProdutoId,
                    Quantidade: v.Quantidade,
                    PrecoUnitario: v.PrecoUnitario,
                    ValorTotal: v.ValorTotal,
                    DataVenda: v.DataVenda,
                    FormaPagamento: v.FormaPagamento.ToString(),
                    Observacoes: v.Observacoes
                )).ToList() ?? new List<VendaResponseDTO>()
            );
        }
    }
}
