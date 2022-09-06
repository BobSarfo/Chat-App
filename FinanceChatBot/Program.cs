using Plain.RabbitMQ;
using RabbitMQ.Client;
using StockChatBot.Clients;
using StockChatBot.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<StockService>();
builder.Services.AddSingleton<IStockService, StockService>();
builder.Services.AddSingleton<IStockRestClient, StockRestClient>();

//Message Queues Setup
builder.Services.AddSingleton<IConnectionProvider>(
    new ConnectionProvider(builder.Configuration.GetValue<string>("RabbitMqConfigUrl")));

builder.Services.AddSingleton<IPublisher>(x => new Publisher(x.GetService<IConnectionProvider>(),
        "stockbot_exchange",
        ExchangeType.Topic));

builder.Services.AddSingleton<ISubscriber>(x => new Subscriber(x.GetService<IConnectionProvider>(),
    "chat_exchange",
    "chat_queue",
    "chatmessage.*",
    ExchangeType.Topic));

builder.Services.AddHostedService<StockBot>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.Run();
