using AutoMapper;
using Core.domain;
using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.posts;
using Manager.interfaces.manager;
using Manager.interfaces.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.implementation
{
    public class PostManager: IPostManager
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;
        private readonly string caminhoUpload = "C:/xampp/htdocs/otakumeet/";

        public PostManager(IPostRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<ICollection<Post>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ICollection<Post>> GetAllPostByPersonagemAsync(int id)
        {
            return await _repository.GetAllPostPersonagemAsync(id);
        }

        public async Task<ICollection<Post>> GetAllPostOfPersonagesFollowingAsync(int idpersonagem)
        {
            return await _repository.GetAllPostOfPersonagesFollowingAsync(idpersonagem);
        }

        public async Task<ICollection<Post>> Search(string word)
        {
            return await _repository.GetSearchPostAsync(word);
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Post> PostPostAsync(NovoPost novoPost)
        {
            var item = _mapper.Map<Post>(novoPost);
            if(novoPost.File  != null)
            {
                item.ImgUrl = await UploadFile(novoPost);
            }
            return await _repository.PostAsync(item);
        }

        public async Task<Post> AddeRemoveEstarelaPostAsync(AddEstrela addEstrela)
        {
            return await _repository.AddeRemoveEstarelaPostAsync(addEstrela);
        }

        public async Task RemoveEstrelaAsync(AddEstrela addEstrela)
        {
            await _repository.RemoveEstrelaAsync(addEstrela);
        }

        public async Task<Post> PutPostAsync(AlterarPost alterarPost)
        {
            var item = _mapper.Map<Post>(alterarPost);
            return await _repository.PutAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<string> UploadFile(NovoPost novoPost)
        {
            var path = Path.Combine(caminhoUpload, novoPost.File.FileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await novoPost.File.CopyToAsync(fileStream);
                fileStream.Close();
            }

            return Path.Combine("http://127.0.0.1:5501/otakumeet/" + novoPost.File.FileName);
        }
    }
}
