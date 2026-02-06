using BiotokkaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Interfaces.Repositories
{
    public interface IVendaRepository : IbaseRepository<Venda>
    {
        List<Venda> GetVendasByDatas(DateTime dataInicio, DateTime dataFim);
        List<Venda> GetVendasByCliente(int clienteId);
        List<Venda> GetVendasByProduto(int produtoId);
    }
}
