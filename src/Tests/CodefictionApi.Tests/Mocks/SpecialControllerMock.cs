using Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers;
using CodefictionApi.Core.Contracts;
using Moq;

namespace CodefictionApi.Tests.Mocks
{
    public class SpecialControllerMock : SpecialController
    {
        private SpecialControllerMock(Mock<IPodcastService> podcastService)
            : base(podcastService.Object)
        {
            PodcastService = podcastService;
        }

        public Mock<IPodcastService> PodcastService { get; set; }

        public static SpecialControllerMock Create()
        {
            return new SpecialControllerMock(new Mock<IPodcastService>(MockBehavior.Strict));
        }
    }
}