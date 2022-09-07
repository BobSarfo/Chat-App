using ChatApp.Domain.Repositories;
using ChatApp.Infrastructure.Repositories;
using ChatApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Config
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
            services.AddScoped<IRoomMessageRepository, MessageRepository>();


            return services;
        }
    }
}
