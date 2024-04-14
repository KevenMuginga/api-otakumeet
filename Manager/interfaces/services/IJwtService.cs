using Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.services
{
    public interface IJwtService
    {
        string GerarToken(Usuario usuario);
    }
}
