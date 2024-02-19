using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class MyHub:Hub
    {
        public async Task SendMessageAsyc(string message)
        {
           await Clients.All.SendAsync("receiveMessage",message);
        }
    }
}
