using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using StockChatBot.Clients;
using StockChatBot.Dto;
using StockChatBot.Models;
using System;
using System.Net;
using System.Runtime.ConstrainedExecution;
using Xunit;
using Xunit.Sdk;

namespace StockChatBot.Services.Tests
{
    public class StockServiceTests
    {
        private readonly Mock<IStockRestClient> _stockRestClientMock = new();
        private readonly Mock<ILogger<StockService>> _loggerMock = new();

        private StockService? _sut;

        [Fact()]
        public async Task ShouldFetchStockAsList()
        {
            _sut = new StockService(_stockRestClientMock.Object, _loggerMock.Object);

            var stockCode = "aapl.us";
            var expectedReturnedStockCode = "AAPL.US";
            _stockRestClientMock.Setup(client => client.GetStocksAsync(It.IsAny<string>()))
                .ReturnsAsync(() => new List<Stock>
                {
                    new(){
                    Symbol = "AAPL.US",
                    Date = "2022-09-02",
                    Time = "22:00:07",
                    Open = "159.75",
                    High = "160.362",
                    Low = "154.965",
                    Close = "155.81",
                    Volume = "76957768"
                }});
            var stocks = await _sut.GetStockByCodeAsync(stockCode);
            stocks.First().Symbol.Should().Be(expectedReturnedStockCode);
            stocks.Should().Contain(stocks);
            stocks.Should().NotBeEmpty();
        }



        [Fact()]
        public async Task ShouldReturnErrorMessageWhenRequestMessageIsNull()
        {
            _sut = new StockService(_stockRestClientMock.Object, _loggerMock.Object);

            var requestTobot = new RequestToStockBotDto
            {
                Message = null,
                ChatRoomName = "",
                ChatRoomId =0,
                RecieverConnectionId ="",
                SenderConnectionId = "", 
            };

            var response = await _sut.BotRequestHandler(requestTobot);

            var expectErrorMessage = "No Stock Code";

            response.ErrorMessage.Should().NotBeNull();
            response.ErrorMessage.Should().Be(expectErrorMessage);
        }


        [Fact()]
        public async Task ShouldReturnErrorMessageWhenRequestToApiReturnBadRequest()
        {

            _sut = new StockService(_stockRestClientMock.Object, _loggerMock.Object);

            var stockCode = "/stock=app";

            _stockRestClientMock.Setup(client => client.GetStocksAsync(stockCode))
           .ReturnsAsync(() => throw new NullReferenceException("something wrong"));

            var requestTobot = new RequestToStockBotDto
            {
                Message = stockCode,
                ChatRoomName = "",
                ChatRoomId = 0,
                RecieverConnectionId = "",
                SenderConnectionId = "",
            };
       
            var response = await _sut.BotRequestHandler(requestTobot);

            var expectErrorMessage = "Bot Server Error Occurred Getting Stock Data";

            response.ErrorMessage.Should().NotBeNull();
            //todo : configure exception
            //response.ErrorMessage.Should().Be(expectErrorMessage);
        }



        [Fact()]
        public async Task ShouldReturnErrorMessageWhenRequestToApiReturnInvalidData()
        {
            _sut = new StockService(_stockRestClientMock.Object, _loggerMock.Object);
            _sut = new StockService(_stockRestClientMock.Object, _loggerMock.Object);

            var stockCode = "/stock=TTTX";
            _stockRestClientMock.Setup(client => client.GetStocksAsync(It.IsAny<string>()))
                 .ReturnsAsync(() => new List<Stock>
                 {
                    new(){
                    Symbol = "TTTX",
                    Date = "N/D",
                    Time = "N/D",
                    Open = "N/D",
                    High = "N/D",
                    Low = "N/D",
                    Close = "N/D",
                    Volume = "N/D"
                }});

            var requestTobot = new RequestToStockBotDto
            {
                Message= stockCode,
            };

            var response = await _sut.BotRequestHandler(requestTobot);

            var expectErrorMessage = "No Stocks Information Found: Invalid Stock Code";

            response.ErrorMessage.Should().NotBeNull();
            response.ErrorMessage.Should().Be(expectErrorMessage);
        }

        [Fact()]
        public async Task ShouldReturnErrorMessageWhenRequestReturnsNull()
        {
            _sut = new StockService(_stockRestClientMock.Object, _loggerMock.Object);
            _sut = new StockService(_stockRestClientMock.Object, _loggerMock.Object);

            var stockCode = "/stock=TTTX";
            
            
            _stockRestClientMock.Setup(client => client.GetStocksAsync(It.IsAny<string>()))
                 .ReturnsAsync(() => null);

            var requestTobot = new RequestToStockBotDto
            {
                Message = stockCode,
            };

            var response = await _sut.BotRequestHandler(requestTobot);

            var expectErrorMessage = "No Information Found";

            response.ErrorMessage.Should().NotBeNull();
            response.ErrorMessage.Should().Be(expectErrorMessage);
        }


        [Fact()]
        public async Task ShouldReturnMessageAndSuccessTrue()
        {
            _sut = new StockService(_stockRestClientMock.Object, _loggerMock.Object);

            var stockCode = "/stock=aapl.us";
            var expectedReturnedStockCode = "AAPL.US";
            _stockRestClientMock.Setup(client => client.GetStocksAsync(It.IsAny<string>()))
                .ReturnsAsync(() => new List<Stock>
                {
                    new(){
                    Symbol = "AAPL.US",
                    Date = "2022-09-02",
                    Time = "22:00:07",
                    Open = "159.75",
                    High = "160.362",
                    Low = "154.965",
                    Close = "155.81",
                    Volume = "76957768"
                }});

            var requestTobot = new RequestToStockBotDto
            {
                Message = stockCode,
                ChatRoomName = "",
                ChatRoomId = 0,
                RecieverConnectionId = "",
                SenderConnectionId = "",
            };

            var response = await _sut.BotRequestHandler(requestTobot);

            var expectedMessage = $"AAPL.US quote is $159.75 per share";

            response.Message.Should().Be(expectedMessage);
            response.IsSuccess.Should().BeTrue();   
        }
    }
}