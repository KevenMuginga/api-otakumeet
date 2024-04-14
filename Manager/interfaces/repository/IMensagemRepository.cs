using Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.repository
{
    public interface IMensagemRepository
    {
        Task<ICollection<Mensagem>> GetAllByChatAsync(Grupo chat);
        Task<ICollection<Mensagem>> GetAllByChatIdAsync(int id);
        Task<Mensagem> PostAsync(Mensagem mensagem);
    }
}
