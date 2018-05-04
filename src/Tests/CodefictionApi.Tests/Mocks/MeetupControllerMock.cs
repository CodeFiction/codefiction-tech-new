using Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers;
using CodefictionApi.Core.Contracts;
using Moq;

namespace CodefictionApi.Tests.Mocks
{
    public class MeetupControllerMock : MeetupController
    {
        private MeetupControllerMock(Mock<IMeetupService> meetupService) 
            : base(meetupService.Object)
        {
            MeetupService = meetupService;
        }

        public Mock<IMeetupService> MeetupService { get; set; }

        public static MeetupControllerMock Create()
        {
            return new MeetupControllerMock(new Mock<IMeetupService>(MockBehavior.Strict));
        }
    }
}
