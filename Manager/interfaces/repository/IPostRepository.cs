using Core.domain;
using CoreShared.modelsView.posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.repository
{
    public interface IPostRepository
    {
        Task<Post> AddeRemoveEstarelaPostAsync(AddEstrela addEstrela);
        Task DeleteAsync(int Id);
        Task<ICollection<Post>> GetAllAsync();
        Task<ICollection<Post>> GetAllPostOfPersonagesFollowingAsync(int myId);
        Task<ICollection<Post>> GetAllPostPersonagemAsync(int Id);
        Task<Post> GetByIdAsync(int Id);
        Task<ICollection<Post>> GetSearchPostAsync(string word);
        Task<Post> PostAsync(Post post);
        Task<Post> PutAsync(Post post);
        Task RemoveEstrelaAsync(AddEstrela addEstrela);
    }
}
