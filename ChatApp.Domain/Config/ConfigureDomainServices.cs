using ChatApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Domain.Config
{
    public static class ConfigureDomainServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomMessageService, RoomMessageService>();
            services.AddScoped<IOnlineUserService, OnlineUserService>();
            services.AddScoped<IChatRoomService, ChatRoomService>();

            return services;
        }
    }
}
