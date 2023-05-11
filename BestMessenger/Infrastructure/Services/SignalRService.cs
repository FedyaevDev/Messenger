using Microsoft.AspNetCore.SignalR.Client;
using Models.Models;
using Models.ModelShells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestMessenger.Infrastructure.Services
{
    public class SignalRService
    {
        private readonly HubConnection _hubConnection;
        public event Action<Message> MessageReceivedEvent;
        public event Action<UserShellForServer> UserReceivedEvent;


        public SignalRService(HubConnection hubConnection)
        {
            _hubConnection = hubConnection;
            _hubConnection.On<Message>("ReceiveMessage", message => MessageReceivedEvent?.Invoke(message));
            _hubConnection.On<UserShellForServer>("ReceiveUser", user => UserReceivedEvent?.Invoke(user));
        }
        public async Task Connect(UserShellForServer user)
        {
            await _hubConnection.StartAsync();
            await _hubConnection.SendAsync("SendUser", user);
        }
        public async Task SendMessage(Message message)
        {
            await _hubConnection.SendAsync("SendMessage",message);
        }
    }
}
