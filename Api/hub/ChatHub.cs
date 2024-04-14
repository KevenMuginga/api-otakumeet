using Core.domain;
using Microsoft.AspNetCore.SignalR;

namespace Api.hub
{
    public class ChatHub: Hub
    {

        public async Task AddToGroup(string groupName, string connectionId)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
            //await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task SendMessage(Mensagem mensagem)
        {
            await Clients.Group(mensagem.ToGrupo.Nome).SendAsync("receberMensagem",mensagem.Descricao);
        }

        public async Task SendMessage2(Mensagem mensagem, string grupo)
        {
            await Clients.Group(mensagem.ToGrupo.Nome).SendAsync("receberMensagem", mensagem.Descricao);
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }
    }
}
