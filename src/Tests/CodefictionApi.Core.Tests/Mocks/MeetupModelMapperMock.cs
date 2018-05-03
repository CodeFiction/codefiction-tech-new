using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Services.Mappers;
using Moq;

namespace CodefictionApi.Core.Tests.Mocks
{
    public class MeetupModelMapperMock : MeetupModelMapper
    {
        private MeetupModelMapperMock(Mock<IPersonService> personService, Mock<IVideoService> videoService, Mock<ISponsorService> sponsorService) 
            : base(personService.Object, videoService.Object, sponsorService.Object)
        {
            PersonService = personService;
            VideoService = videoService;
            SponsorService = sponsorService;
        }

        public Mock<IPersonService> PersonService { get; set; }

        public Mock<IVideoService> VideoService { get; set; }

        public Mock<ISponsorService> SponsorService { get; set; }

        public static MeetupModelMapperMock Create()
        {
            return new MeetupModelMapperMock(new Mock<IPersonService>(MockBehavior.Strict),
                                             new Mock<IVideoService>(MockBehavior.Strict),
                                             new Mock<ISponsorService>(MockBehavior.Strict));
        }
    }
}
