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
    public class PodcastControllerTests
    {
        [Fact]
        public async Task Podcasts_Should_Call_IPodcastService_GetPodcasts_And_Return_Ok()
        {
            PodcastControllerMock mock = PodcastControllerMock.Create();

            mock.PodcastService.Setup(service => service.GetPodcasts()).ReturnsAsync(() => new List<IPodcastModel>());

            IActionResult actionResult = await mock.Podcasts();

            var okObjectResult = actionResult as OkObjectResult;

            Assert.NotNull(okObjectResult);

            var podcastModels = okObjectResult.Value as List<IPodcastModel>;

            Assert.NotNull(podcastModels);
            mock.PodcastService.Verify(service => service.GetPodcasts(), Times.Once);
        }

        [Fact]
        public async Task PodcastBySlug_Should_Return_BadRequest_If_ModelState_Is_Invalid()
        {
            PodcastControllerMock mock = PodcastControllerMock.Create();
            mock.ModelState.AddModelError("test", "test");

            IActionResult actionResult = await mock.PodcastBySlug("birinci-bolum-dotnet-core");

            var badRequestObjectResult = actionResult as BadRequestObjectResult;

            Assert.NotNull(badRequestObjectResult);

            var serializableError = badRequestObjectResult.Value as SerializableError;

            Assert.NotNull(serializableError);
            Assert.True(((string[])serializableError["test"])[0] == "test");
            mock.PodcastService.Verify(service => service.GetPodcastBySlug(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task PodcastBySlug_Should_Call_IPodcastService_GetPodcastBySlug_And_Return_NotFound_If_IMeetupService_GetPodcastBySlug_Returns_Null()
        {
            PodcastControllerMock mock = PodcastControllerMock.Create();

            mock.PodcastService.Setup(service => service.GetPodcastBySlug(It.IsAny<string>())).ReturnsAsync(() => null);

            IActionResult actionResult = await mock.PodcastBySlug("birinci-bolum-dotnet-core");

            var notFoundResult = actionResult as NotFoundResult;

            Assert.NotNull(notFoundResult);
            mock.PodcastService.Verify(service => service.GetPodcastBySlug(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task PodcastBySlug_Should_Call_IPodcastService_GetPodcastBySlug_And_Return_Ok()
        {
            PodcastControllerMock mock = PodcastControllerMock.Create();

            var slug = "birinci-bolum-dotnet-core";

            mock.PodcastService.Setup(service => service.GetPodcastBySlug(It.Is<string>(i => i == slug))).ReturnsAsync(() => new PodcastModel());

            IActionResult actionResult = await mock.PodcastBySlug(slug);

            var okObjectResult = actionResult as OkObjectResult;

            Assert.NotNull(okObjectResult);

            var podcastModel = okObjectResult.Value as PodcastModel;

            Assert.NotNull(podcastModel);
            mock.PodcastService.Verify(service => service.GetPodcastBySlug(It.IsAny<string>()), Times.Once);
        }
    }
}
