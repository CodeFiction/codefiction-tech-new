using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Models;
using CodefictionApi.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CodefictionApi.Tests
{
    public class SpecialControllerTests
    {
        [Fact]
        public async Task Specials_Should_Call_IPodcastService_GetSpecials_And_Return_Ok()
        {
            SpecialControllerMock mock = SpecialControllerMock.Create();

            mock.PodcastService.Setup(service => service.GetSpecials()).ReturnsAsync(() => new List<IPodcastModel>());

            IActionResult actionResult = await mock.Specials();

            var okObjectResult = actionResult as OkObjectResult;

            Assert.NotNull(okObjectResult);

            var podcastModels = okObjectResult.Value as List<IPodcastModel>;

            Assert.NotNull(podcastModels);
            mock.PodcastService.Verify(service => service.GetSpecials(), Times.Once);
        }

        [Fact]
        public async Task SpecialBySlug_Should_Return_BadRequest_If_ModelState_Is_Invalid()
        {
            SpecialControllerMock mock = SpecialControllerMock.Create();
            mock.ModelState.AddModelError("test", "test");

            IActionResult actionResult = await mock.SpecialBySlug("microsoft-ozel-yayini");

            var badRequestObjectResult = actionResult as BadRequestObjectResult;

            Assert.NotNull(badRequestObjectResult);

            var serializableError = badRequestObjectResult.Value as SerializableError;

            Assert.NotNull(serializableError);
            Assert.True(((string[])serializableError["test"])[0] == "test");
            mock.PodcastService.Verify(service => service.GetSpecialBySlug(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task SpecialBySlug_Should_Call_IPodcastService_GetSpecialBySlug_And_Return_NotFound_If_IMeetupService_GetSpecialBySlug_Returns_Null()
        {
            SpecialControllerMock mock = SpecialControllerMock.Create();

            mock.PodcastService.Setup(service => service.GetSpecialBySlug(It.IsAny<string>())).ReturnsAsync(() => null);

            IActionResult actionResult = await mock.SpecialBySlug("microsoft-ozel-yayini");

            var notFoundResult = actionResult as NotFoundResult;

            Assert.NotNull(notFoundResult);
            mock.PodcastService.Verify(service => service.GetSpecialBySlug(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task SpecialBySlug_Should_Call_IPodcastService_GetSpecialBySlug_And_Return_Ok()
        {
            SpecialControllerMock mock = SpecialControllerMock.Create();

            var slug = "microsoft-ozel-yayini";

            mock.PodcastService.Setup(service => service.GetSpecialBySlug(It.Is<string>(i => i == slug))).ReturnsAsync(() => new SpecialModel());

            IActionResult actionResult = await mock.SpecialBySlug(slug);

            var okObjectResult = actionResult as OkObjectResult;

            Assert.NotNull(okObjectResult);

            var specialModel = okObjectResult.Value as SpecialModel;

            Assert.NotNull(specialModel);
            mock.PodcastService.Verify(service => service.GetSpecialBySlug(It.IsAny<string>()), Times.Once);
        }
    }
}
