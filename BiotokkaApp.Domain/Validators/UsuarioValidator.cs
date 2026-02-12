using BiotokkaApp.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiotokkaApp.Domain.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            //Regra de validação do nome do usuário
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .MinimumLength(6).WithMessage("O nome do usuário deve ter pelo menos 6 caracteres.")
                .MaximumLength(100).WithMessage("O nome do usuário deve ter no máximo 100 caracteres.");

            //Regra de validação do email do usuário
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O email do usuário é obrigatório.")
                .EmailAddress().WithMessage("Informe um endereço de email válido.");

            //Regra de validação da senha do usuário
            RuleFor(u => u.Senha)
       .NotEmpty().WithMessage("A senha do usuário é obrigatória.")
       .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$")
       .WithMessage("A senha deve ter letra maiúscula, minúscula, número, símbolo e pelo menos 8 caracteres.");
        }
    }
}
