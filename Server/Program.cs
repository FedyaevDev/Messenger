using Models.Models;
using Models.Models;
using Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Models.ModelShells;
using System.Runtime.Remoting.Messaging;

namespace Server
{
    public class Program
    {
        static List<Client> clients;
        static TcpListener listener;
        static void Main(string[] args)
        {
            clients = new List<Client>();
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"),5000);
            listener.Start();
            Console.WriteLine("Сервер работает");
            while (true)
            {
                clients.Add(new Client(listener.AcceptTcpClient()));
                Console.WriteLine("Клиент подключился");
                BroadcastConnection();
            }

        }

        public static void BroadcastConnection()
        {
            foreach (var item in clients)
            {
                var packet = new PacketBuilder();
                packet.WriteOperation(0);
                packet.SendUser(item.User);
                item.ClientSocket.Client.Send(packet.GetPacket());
            }
        }

        public static void BroadcastMessage(MessageShellForServer message)
        {
            foreach (var item in clients)
            {
                if(item.User.Id == message.Receiver.Id)
                {
                    var packet = new PacketBuilder();
                    packet.WriteOperation(1);
                    packet.SendMessage(message);
                    item.ClientSocket.Client.Send(packet.GetPacket());
                }
              
            }
        }
    }
}
