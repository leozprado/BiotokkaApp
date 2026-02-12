using BiotokkaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IbaseRepository<Usuario>
    {
        Usuario? Get(string email);
        Usuario? Get(string email, string senha);
    }
}
