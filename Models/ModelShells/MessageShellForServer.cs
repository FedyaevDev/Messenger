using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ModelShells
{
    [Serializable]
    public class MessageShellForServer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateOfSend { get; set; }
        public UserShellForServer Sender { get; set; }
        public UserShellForServer Receiver { get; set; }
    }
}
