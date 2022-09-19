using System.Xml.Linq;

namespace ChatApp.Dtos
{
    public class ConnectedUserModel
    {
        public ConnectedUserModel(){}
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string CurrentRoomName { get; set; }
        public List<string> ConnectionIds { get; set; }
    }
}
