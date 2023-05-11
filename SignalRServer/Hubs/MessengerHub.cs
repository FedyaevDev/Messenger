using Microsoft.AspNetCore.SignalR;
using Models.Models;
using Models.ModelShells;
using System.Threading.Tasks;

namespace SignalRServer.Hubs
{
    public class MessengerHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        public async Task SendUser(UserShellForServer user)
        {
            await Clients.All.SendAsync("ReceiveUser", user);
        }
    }
}
