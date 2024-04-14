using AutoMapper;
using Core.domain;
using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.usuarios;
using Manager.interfaces.manager;
using Manager.interfaces.repository;
using Manager.interfaces.services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.implementation
{
    public class LoginManager: ILoginManager
    {
        private readonly IPersonagemRepository _repository;
        private readonly IJwtService jwt;
        private readonly IMapper mapper;
        public LoginManager(IPersonagemRepository _repository, IMapper mapper, IJwtService jwt)
        {
            this._repository = _repository;
            this.mapper = mapper;
            this.jwt = jwt;
        }

        public async Task<PersonagemLogada> Login(LoginUsuario loginUsuario)
        {
            var personagemConsultada = await _repository.GetByNomeAsync(loginUsuario.Personagem, loginUsuario.Anime);
            if (personagemConsultada == null)
            {
                return null;
            }

            if (await ValidaEActualizaHashAsync(loginUsuario, personagemConsultada.Usuario.Senha))
            {
                var personagem = mapper.Map<PersonagemLogada>(personagemConsultada);
                personagem.Token = jwt.GerarToken(personagemConsultada.Usuario);
                return personagem;
            }

            return null;
        }

        private async Task<bool> ValidaEActualizaHashAsync(LoginUsuario loginUsuario, string hash)
        {
            //var usuario = mapper.Map<Usuario>(loginUsuario);
            var passworHasher = new PasswordHasher<LoginUsuario>();
            var status = passworHasher.VerifyHashedPassword(loginUsuario, hash, loginUsuario.Senha);

            switch(status)
            {
                case PasswordVerificationResult.Failed:
                    return false;

                case PasswordVerificationResult.Success:
                    return true;

                default:
                    throw new InvalidOperationException();

            }
        }
    }
}
