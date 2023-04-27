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

        public event Action ConnectedEvent;
        public event Action MessageReceiveEvent;
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
                client.Client.Send(packet.GetPacket());
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
                            ConnectedEvent?.Invoke();
                            break;
                        case 1:
                            MessageReceiveEvent?.Invoke();
                            break;
                        case 2:
                            break;
                        default:
                            break;
                    }
                }
            });
        }

        public void SendMessageToSever(Message message)
        {
            var packet = new PacketBuilder();
            packet.WriteOperation(1);
            packet.SendMessage(message);
            client.Client.Send(packet.GetPacket());
        }
    }
}
