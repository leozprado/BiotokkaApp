using BiotokkaApp.Domain.Entities;
using BiotokkaApp.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
    }
}
