using System.Xml.Linq;

namespace ChatApp.Dtos
{
    public class ConnectedUserDto
    {
        public ConnectedUserDto(){}
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string SelectedRoomName { get; set; }
        public string ConnectionId { get; set; }
    }
}
