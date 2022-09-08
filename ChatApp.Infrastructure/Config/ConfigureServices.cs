using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.Repositories;
using ChatApp.Infrastructure.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure.Config
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
            services.AddScoped<IRoomMessageRepository, RoomMessageRepository>();
            services.AddTransient<IEmailSender, FakeEmailSender>();

            return services;
        }
    }
}
