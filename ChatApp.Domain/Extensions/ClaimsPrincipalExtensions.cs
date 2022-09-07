using System.Security.Claims;

namespace ChatApp.Domain.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {
            int.TryParse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId);
            return userId;
        }
    }
}


