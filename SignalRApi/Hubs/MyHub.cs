using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class MyHub:Hub
    {
        public async Task SendMessage(string message)
        {
          await Clients.All.SendAsync("receiveMessage",message);
        }
    }
}
