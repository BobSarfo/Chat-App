using chat_application.Models;

namespace ChatApp.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string userName);
    }
}
