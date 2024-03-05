using Microsoft.AspNetCore.SignalR;
using Services.ChattingApp.Domain;

namespace Services.ChattingApp.WebAPI.Hubs
{
    public class SignalRHub : Hub
    {
        public async Task BroadcastMessage(string sender, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",$"{sender} said {message}.");
        }
    }
}
