using Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers;
using CodefictionApi.Core.Contracts;
using Moq;

namespace CodefictionApi.Tests.Mocks
{
    public class SponsorControllerMock : SponsorController
    {
        private SponsorControllerMock(Mock<ISponsorService> sponsorService)
            : base(sponsorService.Object)
        {
            SponsorService = sponsorService;
        }

        public Mock<ISponsorService> SponsorService { get; set; }

        public static SponsorControllerMock Create()
        {
            return new SponsorControllerMock(new Mock<ISponsorService>(MockBehavior.Strict));
        }
    }
}