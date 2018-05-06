using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Models;
using CodefictionApi.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CodefictionApi.Tests
{
    public class P2PControllerTests
    {
        [Fact]
        public async Task P2Ps_Should_Call_IPodcastService_GetP2Ps_And_Return_Ok()
        {
            P2PControllerMock mock = P2PControllerMock.Create();

            mock.PodcastService.Setup(service => service.GetP2Ps()).ReturnsAsync(() => new List<IPodcastModel>());

            IActionResult actionResult = await mock.P2Ps();

            var okObjectResult = actionResult as OkObjectResult;

            Assert.NotNull(okObjectResult);

            var podcastModels = okObjectResult.Value as List<IPodcastModel>;

            Assert.NotNull(podcastModels);
            mock.PodcastService.Verify(service => service.GetP2Ps(), Times.Once);
        }

        [Fact]
        public async Task P2PBySlug_Should_Return_BadRequest_If_ModelState_Is_Invalid()
        {
            P2PControllerMock mock = P2PControllerMock.Create();
            mock.ModelState.AddModelError("test", "test");

            IActionResult actionResult = await mock.P2PBySlug("burak-selim-senyurt");

            var badRequestObjectResult = actionResult as BadRequestObjectResult;

            Assert.NotNull(badRequestObjectResult);

            var serializableError = badRequestObjectResult.Value as SerializableError;

            Assert.NotNull(serializableError);
            Assert.True(((string[])serializableError["test"])[0] == "test");
            mock.PodcastService.Verify(service => service.GetP2PBySlug(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task P2PBySlug_Should_Call_IPodcastService_GetP2PBySlug_And_Return_NotFound_If_IMeetupService_GetP2PBySlug_Returns_Null()
        {
            P2PControllerMock mock = P2PControllerMock.Create();

            mock.PodcastService.Setup(service => service.GetP2PBySlug(It.IsAny<string>())).ReturnsAsync(() => null);

            IActionResult actionResult = await mock.P2PBySlug("burak-selim-senyurt");

            var notFoundResult = actionResult as NotFoundResult;

            Assert.NotNull(notFoundResult);
            mock.PodcastService.Verify(service => service.GetP2PBySlug(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task P2PBySlug_Should_Call_IPodcastService_GetP2PBySlug_And_Return_Ok()
        {
            P2PControllerMock mock = P2PControllerMock.Create();

            var slug = "burak-selim-senyurt";

            mock.PodcastService.Setup(service => service.GetP2PBySlug(It.Is<string>(i => i == slug))).ReturnsAsync(() => new P2PModel());

            IActionResult actionResult = await mock.P2PBySlug(slug);

            var okObjectResult = actionResult as OkObjectResult;

            Assert.NotNull(okObjectResult);

            var p2PModel = okObjectResult.Value as P2PModel;

            Assert.NotNull(p2PModel);
            mock.PodcastService.Verify(service => service.GetP2PBySlug(It.IsAny<string>()), Times.Once);
        }
    }
}
