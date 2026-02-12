using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Dtos.Responses;
using BiotokkaApp.Domain.Entities;
using BiotokkaApp.Domain.Helpers;
using BiotokkaApp.Domain.Interfaces.Repositories;
using BiotokkaApp.Domain.Interfaces.Services;
using BiotokkaApp.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BiotokkaApp.Domain.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository) : IUsuarioService
    {
        public CriarContaResponse CriarConta(CriarContaRequest request)
        {
            
            var usuario = new Usuario
            {
                Nome = request.nome, 
                Email = request.email, 
                Senha = request.senha 
            };
           
            var validator = new UsuarioValidator();
            var result = validator.Validate(usuario);

            //Verificar se existe algum erro de validação no usuário
            if (!result.IsValid)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.ErrorMessage));
                throw new ValidationException(errors);
            }

            //Verificar se já existe outro usuário com o email cadastrado
            if (usuarioRepository.Get(usuario.Email) != null)
            {
                throw new ApplicationException("O email informado já está cadastrado. Tente outro.");
            }

            //Criptografar a senha do usuário
            usuario.Senha = CryptoHelper.ToSha256(usuario.Senha);

            //Consultando o perfil 'OPERADOR' no banco de dados
            var perfil = perfilRepository.Get("OPERADOR");

            //Caso o perfil não existe, iremos cria-lo
            if (perfil == null)
            {
                perfil = new Perfil() { Nome = "OPERADOR" };
                perfilRepository.Add(perfil);
            }

            //Associar o usuário ao perfil de operador
            usuario.PerfilId = perfil.Id; //chave estrangeira

            //Salvar no banco de dados
            usuarioRepository.Add(usuario);

            //Retornar os dados do usuário criado
            return new CriarContaResponse(
                  usuario.Id, //Id do usuário
                  usuario.Nome, //Nome do usuário
                  usuario.Email, //Email do usuário
                  usuario.DataHoraCriacao 
                );
        }

        public AutenticarResponse AutenticarConta(AutenticarRequest request)
        {
            //Buscar o usuário no banco de dados baseado no email e na senha.
            var usuario = usuarioRepository.Get(request.email, CryptoHelper.ToSha256(request.senha));

            //verificar se o usuário não foi encontrado
            if (usuario == null)
            {
                throw new ApplicationException("Acesso negado. Usuário inválido.");
            }

            //gerar o token JWT
            var token = JwtHelper.GenerateToken(usuario.Email, usuario.Perfil?.Nome ?? string.Empty);


            //retornar os dados do usuário autenticado
            return new AutenticarResponse(
                    usuario.Id, //Id do usuário
                    usuario.Nome, //Nome do usuario
                    usuario.Email, //Email do usuário
                    usuario.Perfil?.Nome, //Nome do perfil do usuário
                    DateTime.Now, //Data e hora de acesso
                    DateTime.Now.AddHours(2), //Data e hora de expiração
                    token // Token JWT
                );
        }
    }
}
