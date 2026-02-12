using BiotokkaApp.Domain.Entities;
using BiotokkaApp.Domain.Interfaces.Repositories;
using BiotokkaApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public override Cliente? GetById(int id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Cliente>()
                    .Include(c => c.Vendas)
                    .FirstOrDefault(c => c.Id == id);
            }
        }

        public override List<Cliente> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Cliente>()
                    .Include(c => c.Vendas)
                    .ToList();
            }
        }
    }
}
