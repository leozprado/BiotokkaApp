using BiotokkaApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Validators
{
    public class PerfilValidator : AbstractValidator<Perfil>
    {
        public PerfilValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do perfil é obrigatório.")
                .MinimumLength(4).WithMessage("O nome do perfil deve ter pelo menos 4 caracteres.");
        }

    }
}
