using ChatApp.Domain.Models;

namespace ChatApp.Domain.Extensions
{
    public static class ConnectedUsersExtentions
    {
        public static string? GetConnectionStringByUserName(this IDictionary<string, ConnectedUser> connections, string username)
        {
            foreach (var connection in connections)
            {
                if (username is not null && connection.Value.UserName.ToLower() == username.ToLower())
                {
                    return connection.Key;
                }

            }

            return null;
        }
    }
}
