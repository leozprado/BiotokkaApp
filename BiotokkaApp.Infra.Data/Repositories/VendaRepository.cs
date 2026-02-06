using BiotokkaApp.Domain.Entities;
using BiotokkaApp.Domain.Interfaces.Repositories;
using BiotokkaApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BiotokkaApp.Infra.Data.Repositories
{
    public class VendaRepository : BaseRepository<Venda>, IVendaRepository
    {
        public List<Venda> GetVendasByCliente(int clienteId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Venda>()
                    .Include(v => v.Cliente)
                    .Include(v => v.Produto)
                        .ThenInclude(p => p.Categoria)
                    .Where(v => v.ClienteId == clienteId)
                    .OrderByDescending(v => v.DataVenda)
                    .ToList();
            }
        }

        public List<Venda> GetVendasByDatas(DateTime dataInicio, DateTime dataFim)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Venda>()
                    .Include(v => v.Cliente)
                    .Include(v => v.Produto)
                        .ThenInclude(p => p.Categoria)
                    .Where(v => v.DataVenda >= dataInicio && v.DataVenda <= dataFim)
                    .OrderByDescending(v => v.DataVenda)
                    .ToList();
            }
        }

        public List<Venda> GetVendasByProduto(int produtoId)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Venda>()
                    .Include(v => v.Cliente)
                    .Include(v => v.Produto)
                        .ThenInclude(p => p.Categoria)
                    .Where(v => v.ProdutoId == produtoId)
                    .OrderByDescending(v => v.DataVenda)
                    .ToList();
            }
        }
    }
}
