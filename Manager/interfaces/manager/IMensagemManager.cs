using Core.domain;
using CoreShared.modelsView.mensagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IMensagemManager
    {
        Task<ICollection<Mensagem>> GetAllByChatAsync(Grupo chat);
        Task<ICollection<Mensagem>> GetAllByChatAsync(int id);
        Task<Mensagem> PostAsync(NovaMensagem novaMensagem);
    }
}
