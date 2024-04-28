using Core.domain;
using CoreShared.modelsView.posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IPostManager
    {
        Task<Post> AddeRemoveEstarelaPostAsync(AddEstrela addEstrela);
        Task DeleteAsync(int id);
        Task<ICollection<Post>> GetAllAsync();
        Task<ICollection<Post>> GetAllPostByPersonagemAsync(int id);
        Task<ICollection<Post>> GetAllPostOfPersonagesFollowingAsync(int idpersonagem);
        Task<Post> GetByIdAsync(int id);
        Task<Post> PostPostAsync(NovoPost novoPost);
        Task<Post> PutPostAsync(AlterarPost alterarPost);
        Task RemoveEstrelaAsync(AddEstrela addEstrela);
        Task<ICollection<Post>> Search(string word);
    }
}
