using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Entities
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;

        public List<Usuario>? Usuarios { get; set; }
    }
}
