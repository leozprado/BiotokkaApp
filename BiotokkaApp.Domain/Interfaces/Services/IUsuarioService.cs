using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        CriarContaResponse CriarConta(CriarContaRequest request);

        AutenticarResponse AutenticarConta(AutenticarRequest request);
    }
}
