namespace ChatApp.Interfaces
{
    public interface IUnitOfWork
    {
        IPrivateMessageRepository PrivateMessageRepository { get; }
        IRoomMessageRepository RoomMessageRepository { get; }
        IUserRepository UserRepository { get; }
        IChatRoomRepository ChatRoomRepository { get; }

        Task<bool> Complete();
        bool HasChanges();
    }
}
