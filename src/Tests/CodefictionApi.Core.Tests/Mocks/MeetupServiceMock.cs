using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Services;
using Moq;

namespace CodefictionApi.Core.Tests.Mocks
{
    public class MeetupServiceMock : MeetupService
    {
        private MeetupServiceMock(Mock<IMeetupRepository> meetupRepository, Mock<IMeetupModelMapper> meetupModelMapper)
            : base(meetupRepository.Object, meetupModelMapper.Object)
        {
            MeetupRepository = meetupRepository;
            MeetupModelMapper = meetupModelMapper;
        }

        public Mock<IMeetupRepository> MeetupRepository { get; set; }

        public Mock<IMeetupModelMapper> MeetupModelMapper { get; set; }

        public static MeetupServiceMock Create()
        {
            return new MeetupServiceMock(new Mock<IMeetupRepository>(MockBehavior.Strict),
                                         new Mock<IMeetupModelMapper>(MockBehavior.Strict));
        }
    }
}