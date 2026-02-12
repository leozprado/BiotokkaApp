using BiotokkaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BiotokkaApp.Domain.Interfaces.Repositories
{
    public interface IPerfilRepository : IbaseRepository<Perfil>
    {
        Perfil Get(string nome);
    }
}
