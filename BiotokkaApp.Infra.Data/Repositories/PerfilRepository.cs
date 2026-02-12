using BiotokkaApp.Domain.Entities;
using BiotokkaApp.Domain.Interfaces.Repositories;
using BiotokkaApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Infra.Data.Repositories
{
    public class PerfilRepository : BaseRepository<Perfil>, IPerfilRepository
    {
        public Perfil Get(string nome)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Perfil>().Where(p => p.Nome.Equals(nome)).SingleOrDefault();
            }
        }
    }
}
