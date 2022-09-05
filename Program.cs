using chat_application.Models;
using ChatApp.Data;
using ChatApp.Dtos;
using ChatApp.Hubs;
using ChatApp.Interfaces;
using ChatApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Plain.RabbitMQ;
using RabbitMQ.Client;
using System.Security.Policy;
using Publisher = Plain.RabbitMQ.Publisher;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddResponseCompression(options =>
{
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddSignalR();

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();



builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddScoped<IChatRoomService, ChatRoomService>();
builder.Services.AddScoped<IRoomMessageService, RoomMessageService>();
builder.Services.AddScoped<IPrivateMessageService, PrivateMessageService>();


builder.Services.AddSingleton<IConnectionProvider>(
    new ConnectionProvider(builder.Configuration.GetValue<string>("RabbitMqConfigUrl")));

builder.Services.AddSingleton<IPublisher>(x => new Publisher(x.GetService<IConnectionProvider>(),
        "chat_exchange",
        ExchangeType.Topic));

builder.Services.AddSingleton<ISubscriber>(x => new Subscriber(x.GetService<IConnectionProvider>(),
    "stockbot_exchange",
    "stockbot_queue",
    "stockbotmessage",
    ExchangeType.Topic));

builder.Services.AddHostedService<ChatListner>();

builder.Services.AddSingleton<IDictionary<string, ConnectedUserDto>>(options => new Dictionary<string, ConnectedUserDto>());

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapHub<MessageHub>("hubs/message");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
