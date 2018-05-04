using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Models;
using CodefictionApi.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CodefictionApi.Tests
{
    public class MeetupControllerTests
    {
        [Fact]
        public async Task Meetups_Should_Call_IMeetupService_GetMeetups_And_Return_Ok()
        {
            MeetupControllerMock mock = MeetupControllerMock.Create();

            mock.MeetupService.Setup(service => service.GetMeetups()).ReturnsAsync(() => new List<MeetupModel>());

            IActionResult actionResult = await mock.Meetups();

            var okObjectResult = actionResult as OkObjectResult;

            Assert.NotNull(okObjectResult);

            var meetupModels = okObjectResult.Value as List<MeetupModel>;

            Assert.NotNull(meetupModels);
            mock.MeetupService.Verify(service => service.GetMeetups(), Times.Once);
        }

        [Fact]
        public async Task MeetupById_Should_Return_BadRequest_If_ModelState_Is_Invalid()
        {
            MeetupControllerMock mock = MeetupControllerMock.Create();
            mock.ModelState.AddModelError("test", "test");

            IActionResult actionResult = await mock.MeetupById(1);

            var badRequestObjectResult = actionResult as BadRequestObjectResult;

            Assert.NotNull(badRequestObjectResult);

            var serializableError = badRequestObjectResult.Value as SerializableError;

            Assert.NotNull(serializableError);
            Assert.True(((string[])serializableError["test"])[0] == "test");
            mock.MeetupService.Verify(service => service.GetMeetupById(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task MeetupById_Should_Call_IMeetupService_GetMeetupById_And_Return_NotFound_If_IMeetupService_GetMeetupById_Returns_Null()
        {
            MeetupControllerMock mock = MeetupControllerMock.Create();

            mock.MeetupService.Setup(service => service.GetMeetupById(It.IsAny<int>())).ReturnsAsync(() => null);

            IActionResult actionResult = await mock.MeetupById(1);

            var notFoundResult = actionResult as NotFoundResult;

            Assert.NotNull(notFoundResult);
            mock.MeetupService.Verify(service => service.GetMeetupById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task MeetupById_Should_Call_IMeetupService_GetMeetupById_And_Return_Ok()
        {
            MeetupControllerMock mock = MeetupControllerMock.Create();

            var id = 1;

            mock.MeetupService.Setup(service => service.GetMeetupById(It.Is<int>(i => i == id))).ReturnsAsync(() => new MeetupModel());

            IActionResult actionResult = await mock.MeetupById(id);

            var okObjectResult = actionResult as OkObjectResult;

            Assert.NotNull(okObjectResult);

            var meetupModel = okObjectResult.Value as MeetupModel;

            Assert.NotNull(meetupModel);
            mock.MeetupService.Verify(service => service.GetMeetupById(It.IsAny<int>()), Times.Once);
        }
    }
}
