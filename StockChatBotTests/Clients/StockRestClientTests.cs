using Xunit;
using StockChatBot.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Moq;
using Moq.Protected;
using FluentAssertions;

namespace StockChatBot.Clients.Tests
{
    public class StockRestClientTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock = new();
        private StockRestClient? _sut;

        [Fact]
        public async Task ShouldFetchStockAsList()
        {
            const string body = @"Symbol,Date,Time,Open,High,Low,Close,Volume
                      AAPL.US,2022-09-02,22:00:07,159.75,160.362,154.965,155.81,76957768";
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
                    new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent(body) }
                );

            var client = new HttpClient(_httpMessageHandlerMock.Object);
            _sut = new StockRestClient(client);
            var stockName = "AAPL.US";
            var stocks = await _sut.GetStocksAsync(stockName);
            stocks.Should().NotBeEmpty();
        }


        [Fact]
        public async Task ShouldReturnErrorMessageWhenStocksAPIReturnBadRequest()
        {
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
         "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(
         new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest, Content = new StringContent("") }
     );

            var client = new HttpClient(_httpMessageHandlerMock.Object);
            _sut = new StockRestClient(client);
            var stockName = "AAPL.US";
            var stocks = await _sut.GetStocksAsync(stockName);
            stocks.Should().BeEmpty();
        }
    }
}