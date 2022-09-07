namespace ChatApp.Domain.Services
{
    public interface IOnlineUserService
    {        
        public Task<string?> UpdateUserChatRoom(int chatRoomId, string userName);
    }
}
