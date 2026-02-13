using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Responses
{
    public record AutenticarResponseDTO(
           int id, //Id do usuário
           string nome, //Nome do usuário
           string email, //Email do usuário
           string perfil, //Nome do perfil do usuário
           DateTime dataHoraAcesso, //Data e hora de acesso
           DateTime dataHoraExpiracao, //Data e hora de expiração
           string token //TOKEN JWT
       );
}
