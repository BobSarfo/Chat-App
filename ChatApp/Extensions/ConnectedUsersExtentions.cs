using ChatApp.Dtos;
using System;
namespace ChatApp.Extensions
{
    public static class ConnectedUsersExtentions
    {
        public static string? GetConnectionStringByUserName(this IDictionary<string, ConnectedUserDto> connections, string username)
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
