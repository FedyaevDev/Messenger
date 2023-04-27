using Models.Models;
using Models.ModelShells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Models.Helpers
{
    public class PacketReader : BinaryReader
    {
        NetworkStream stream;
        public PacketReader(NetworkStream stream) : base(stream)
        {
            this.stream = stream;
        }
        public UserShellForServer ReceiveUser()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            var user = (UserShellForServer)binaryFormatter.Deserialize(stream);
            return user;
        }
        public Message ReceiveMessage()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            var message = (Message)binaryFormatter.Deserialize(stream);
            return message;
        }
    }
}
