using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Dtos.Requests
{
    public record AutenticarRequest(
           
           string email, 
           string senha
       );
}
