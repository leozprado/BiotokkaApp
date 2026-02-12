using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
        public string Senha { get; set; } = string.Empty; 
        public DateTime DataHoraCriacao { get; set; } = DateTime.Now;
        public int PerfilId { get; set; }



        public Perfil? Perfil { get; set; }
    }
}
