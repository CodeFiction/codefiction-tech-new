using System.Collections.Generic;
using System.Threading.Tasks;
using CodefictionApi.Core.Data;
using CodefictionApi.Core.Models;
using CodefictionApi.Core.Tests.Mocks;
using Moq;
using Xunit;

namespace CodefictionApi.Core.Tests
{
    public class MeetupServiceTests
    {
        [Fact]
        public async Task GetMeetups_Should_Return_Call_IMeetupRepository_GetMeetups()
        {
            MeetupServiceMock mock = MeetupServiceMock.Create();

            mock.MeetupRepository.Setup(repository => repository.GetMeetups()).ReturnsAsync(() => new List<Meetup>());
            mock.MeetupModelMapper.Setup(mapper => mapper.Map(It.IsAny<IEnumerable<Meetup>>())).ReturnsAsync(() => new List<MeetupModel>());

            IEnumerable<MeetupModel> meetupModels = await mock.GetMeetups();

            mock.MeetupRepository.Verify(repository => repository.GetMeetups(), Times.Once);
            Assert.NotNull(meetupModels);
        }

        [Fact]
        public async Task GetMeetups_Should_Return_Call_IMeetupModelMapper_Map()
        {
            MeetupServiceMock mock = MeetupServiceMock.Create();

            var meetups = new List<Meetup>() {new Meetup() {Id = 1, Title = "Dotnet Core"}};

            mock.MeetupRepository
                .Setup(repository => repository.GetMeetups())
                .ReturnsAsync(() => meetups);

            mock.MeetupModelMapper.Setup(mapper => mapper.Map(It.Is<IEnumerable<Meetup>>(m => m.Equals(meetups)))).ReturnsAsync(() => new List<MeetupModel>());

            IEnumerable<MeetupModel> meetupModels = await mock.GetMeetups();

            mock.MeetupModelMapper.Verify(repository => repository.Map(It.IsAny<IEnumerable<Meetup>>()), Times.Once);
            Assert.NotNull(meetupModels);
        }

        [Fact]
        public async Task GetMeetup_By_Id_Should_Return_Call_IMeetupRepository_GetMeetupById()
        {
            MeetupServiceMock mock = MeetupServiceMock.Create();

            var id = 1;

            var meetup = new Meetup() {Id = id, Title = "Dotnet Core"};

            mock.MeetupRepository
                .Setup(repository => repository.GetMeetupById(It.Is<int>(i => i == id)))
                .ReturnsAsync(() => new Meetup() {Id = id, Title = "Dotnet Core"});

            mock.MeetupModelMapper
                .Setup(mapper => mapper.Map(It.IsAny<Meetup>()))
                .ReturnsAsync(() => new MeetupModel());

            MeetupModel meetupModel = await mock.GetMeetupById(id);

            mock.MeetupRepository.Verify(repository => repository.GetMeetupById(It.IsAny<int>()), Times.Once);
            Assert.NotNull(meetupModel);
        }

        [Fact]
        public async Task GetMeetup_By_Id_Should_Return_Call_IMeetupModelMapper_Map()
        {
            MeetupServiceMock mock = MeetupServiceMock.Create();

            var id = 1;

            var meetup = new Meetup() { Id = id, Title = "Dotnet Core" };

            mock.MeetupRepository
                .Setup(repository => repository.GetMeetupById(It.Is<int>(i => i == id)))
                .ReturnsAsync(() => new Meetup() { Id = id, Title = "Dotnet Core" });

            mock.MeetupModelMapper
                .Setup(mapper => mapper.Map(It.Is<Meetup>(m => m.Id == meetup.Id && m.Title == meetup.Title)))
                .ReturnsAsync(() => new MeetupModel());

            MeetupModel meetupModel = await mock.GetMeetupById(id);

            mock.MeetupModelMapper.Verify(mapper => mapper.Map(It.IsAny<Meetup>()), Times.Once);
            Assert.NotNull(meetupModel);
        }
    }
}
