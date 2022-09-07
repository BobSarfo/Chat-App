# ChatBot Web Application
A chat bot web application code.

### Features
- Authentication with Identity
- balloon: &nbsp;Chat Room for logged users
- Command **/stock=*code*** gets price of stock from Stooq
- Command errors are handled by bot 
- Messages are ordered by time (older ones are shown in top)
- Only 50 messages are displayed in the chat ( No need to reload the page)

### Built with
* [Docker :whale:](https://docker.com) 
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/)
* [IdentityServer](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore)
* [RabbitMQ](https://www.rabbitmq.com/)
* [Signal R]()

## Getting Started

### Prerequisites

- .NET 6 Build Sdk & .NET 6 Runtime
- Microsoft SQL Server 2017
- RabbitMQ

## Usage

### Project Setup
1. Start your RabbitMQ Server + MSSQL Server 2017
2. Update the appSettings in ChatApp/appsettings.json 
3. In the root folder, run
  ```
  dotnet restore
  dotnet build
  ```
4. Then, start ChatApp with
  ```
  cd ChatApp
  dotnet run
  ```

5. In another terminal, run the Bot, to start the bot application  
  ```
  cd StockChatBot
  dotnet run
  ```

6. Open your browser in http://localhost:5063 
7. Create your account
8. Start chatting

If you have visual studio or rider simple run the solution file in developement. 👌😉

### Tests
On the project root, run this command to run all tests
  ```
  cd StockChatBotTests
  dotnet test
  ```
 