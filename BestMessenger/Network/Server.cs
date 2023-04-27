using Models.Helpers;
using Models.Models;
using Models.ModelShells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BestMessenger.Network
{
    public class Server
    {
        private TcpClient client;
        private PacketBuilder _packetBuilder;
        public PacketReader PacketReader { get; private set; }

        public event Action<UserShellForServer> ConnectedEvent;
        public event Action<MessageShellForServer> MessageReceiveEvent;
        public event Action DisconnectedEvent;


        public Server()
        {
            client = new TcpClient();
        }
        public void ConnectedToServer(UserShellForServer user )
        {
            if (client.Connected == false)
            {
                client.Connect("127.0.0.1",5000);
                var packet = new PacketBuilder();
                PacketReader = new PacketReader(client.GetStream());

                packet.SendUser(user);
                client.Client.Send(packet.GetPacket()); // F1 Test byte[]
                ReadInputPackets();
            }
        }

        private void ReadInputPackets()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    var operation = PacketReader.ReadByte();
                    switch (operation)
                    {
                        case 0:
                            UserShellForServer user = PacketReader.ReceiveUser();
                            ConnectedEvent?.Invoke(user);
                            //if (ConnectedEvent != null) ConnectedEvent(user);
                            break;
                        case 1:
                            var message = PacketReader.ReceiveMessage();
                            MessageReceiveEvent?.Invoke(message);
                            break;
                        case 2:
                            break;
                        default:
                            break;
                    }
                }
            });
        }

        public void SendMessageToSever(MessageShellForServer message)
        {
            var packet = new PacketBuilder();
            packet.WriteOperation(1);
            packet.SendMessage(message);
            client.Client.Send(packet.GetPacket());
        }
    }
}
