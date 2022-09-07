namespace ChatApp.Domain.Services
{
    internal interface IOnlineUserService
    {        
        public Task<string?> UpdateChatRoom(int chatRoomId, string userName);
    }
}
