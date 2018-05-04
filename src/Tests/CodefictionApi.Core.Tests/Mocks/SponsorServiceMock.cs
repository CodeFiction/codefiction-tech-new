using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Services;
using Moq;

namespace CodefictionApi.Core.Tests.Mocks
{
    public class SponsorServiceMock : SponsorService
    {
        private SponsorServiceMock(Mock<ISponsorRepository> sponsorRepository)
            : base(sponsorRepository.Object)
        {
            SponsorRepository = sponsorRepository;
        }

        public Mock<ISponsorRepository> SponsorRepository { get; set; }

        public static SponsorServiceMock Create()
        {
            return new SponsorServiceMock(new Mock<ISponsorRepository>(MockBehavior.Strict));
        }
    }
}