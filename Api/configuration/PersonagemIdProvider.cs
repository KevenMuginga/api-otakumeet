using Azure.Core;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Api.configuration
{
    public class PersonagemIdProvider: IUserIdProvider
    {

        public string? GetUserId(HubConnectionContext connection)
        {
            return connection.User.FindFirst(ClaimTypes.Name).Value;
        }
    }
}
