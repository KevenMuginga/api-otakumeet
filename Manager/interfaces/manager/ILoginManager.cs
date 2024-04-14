using CoreShared.modelsView.Personagens;
using CoreShared.modelsView.usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface ILoginManager
    {
        Task<PersonagemLogada> Login(LoginUsuario loginUsuario);
    }
}
