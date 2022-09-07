using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Domain.Models
{
    public class ConnectedUser
    {
        public ConnectedUser() { }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string SelectedRoomName { get; set; }
        public string ConnectionId { get; set; }
    }
}
