namespace ChatApp.Interfaces
{
    public interface IUnitOfWork
    {
        IPrivateMessageRepository PrivateMessage { get; }
        IRoomMessageRepository RoomMessage { get; }
        IUserRepository UserRepository { get; }
        IChatRoomRepository ChatRoom { get; }

        Task<bool> Complete();
        bool HasChanges();
    }
}
