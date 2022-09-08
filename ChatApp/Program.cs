using ChatApp.Domain.Config;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Models;
using ChatApp.Dtos;
using ChatApp.Hubs;
using ChatApp.Infrastructure.Config;
using ChatApp.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Plain.RabbitMQ;
using RabbitMQ.Client;
using Publisher = Plain.RabbitMQ.Publisher;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ChatAppDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ChatApp"))
    );


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddResponseCompression(options =>
{
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

//Asp Identity
builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 5;
})
    .AddEntityFrameworkStores<ChatAppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddInfrastructureServices();
builder.Services.AddDomainServices();


//Message Queue Config
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


//Signal R
builder.Services.AddSignalR();
builder.Services.AddSingleton((Func<IServiceProvider, IDictionary<string,ConnectedUser>>)(options => new Dictionary<string, ConnectedUser>()));

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
