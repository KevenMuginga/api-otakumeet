using AutoMapper;
using Core.domain;
using CoreShared.modelsView.Animes;
using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.usuarios;
using Manager.interfaces.manager;
using Manager.interfaces.repository;
using Microsoft.AspNetCore.Identity;

namespace Manager.implementation
{
    public class UsuarioManager : IUsuarioManager
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioManager(IUsuarioRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ICollection<Usuario>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Usuario> PostPersnoangemAsync(NovoUsuario novoUsuario)
        {
            var item = _mapper.Map<Usuario>(novoUsuario);
            CovertSenhaTOHash(item);
            return await _repository.PostAsync(item);
        }

        private void CovertSenhaTOHash(Usuario usuario)
        {
            var passworHash = new PasswordHasher<Usuario>();
            usuario.Senha = passworHash.HashPassword(usuario, usuario.Senha);
        }


        public async Task DeleteUsuarioAsync(int id)
        {
            
            await _repository.DeleteUsuarioAsync(id);
        }
    }
}
