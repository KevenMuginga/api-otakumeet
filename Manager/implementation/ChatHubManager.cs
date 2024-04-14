using Core.domain;
using Manager.interfaces.manager;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.implementation
{
    public class ChatHubManager: Hub, IChatHubManager
    {

        public async Task AddToGroup(string groupName, string connectionId)
        {
                await Groups.AddToGroupAsync(connectionId, groupName);

                await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task AddToGroup2(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        //public async Task NewMessage(Mensagem mensagem)
        //{
        //    await Clients.Group(mensagem.ToGrupo.Nome).SendAsync("newMessage", Convert.ToString(mensagem.PersonagemId), mensagem.Descricao);
            
        //}

        public async Task NewMessage(string grupo, int usuario, string descricao)
        {
            await Clients.Group(grupo).SendAsync("newMessage", usuario, descricao);
        }

        public async Task RemoveFromGroup(string groupName)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

                await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
            }
        
    }
}
