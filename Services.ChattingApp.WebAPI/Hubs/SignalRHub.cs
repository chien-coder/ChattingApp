using Microsoft.AspNetCore.SignalR;
using Services.ChattingApp.Domain;

namespace Services.ChattingApp.WebAPI.Hubs
{
    public class SignalRHub : Hub
    {
        public async Task BroadcastMessage(string sender, string message, string group)
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", $"{sender} said {message}.");
        }

        public async Task JoinGroup(string group)
        {
            await this.Groups.AddToGroupAsync(this.Context.ConnectionId, group);
            await this.Clients.Group(group).SendAsync("Send", $"{this.Context.ConnectionId} joined {group}");
        }
    }
}
