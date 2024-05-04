using DTO;
using MessagingService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Post_API.Controllers;
using PostService;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace ServiceTest
{
    public class TestPostService : IAsyncLifetime
    {
        private WireMockServer _timelineService;
        public async Task InitializeAsync()
        {
            _timelineService = WireMockServer.Start(
                new WireMockServerSettings
                {
                    Urls = new[] {"http://localhost:8080"}
                }
                );

            _timelineService.Given(
                Request.Create().WithPath("/timline").UsingGet()
                ).RespondWith(
                Response.Create().WithBodyAsJson(new Timeline { timelineid = 1, PostIDs = [] })
                );
                


        }

        public async Task DisposeAsync()
        {
            _timelineService.Stop();
        }

        [Fact]
        public async void TestGet_ResultTimelineid()
        {
            //Arrange
            var mock = new Mock<IPostService>();
            var controller = new PostController(mock.Object);

            //Act
            var result = await controller.Get();

            //Assert
            Assert.Equal(1 , result.timelineid);
        }
    }
}