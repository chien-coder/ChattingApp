using Microsoft.AspNetCore.SignalR;

namespace Services.ChattingApp.WebAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessageToRoom(string message, string chatRoomName)
        {
            //await this.DatabaseManager.SaveChatHistory(chatRoomName, message).ConfigureAwait(false);

            //await this.Clients.Group(chatRoomName).BroadcastMessageAsync(message);
        }
    }
}
