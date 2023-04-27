using Models.Models;
using Models.ModelShells;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Models.Helpers
{
    public class PacketBuilder
    {
        MemoryStream stream;
        public PacketBuilder()
        {
            stream = new MemoryStream();
        }

        public void WriteOperation(byte operation)
        {
            stream.WriteByte(operation);
        }

        public void SendUser(UserShellForServer user)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, user);
        }
        public void SendMessage(Message message)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, message);
        }

        public byte[] GetPacket()
        {
            return stream.ToArray();
        }
    }
}
