using Core.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.interfaces.manager
{
    public interface IChatHubManager
    {
        Task AddToGroup(string groupName, string connectionId);
        Task RemoveFromGroup(string groupName);
    }
}
