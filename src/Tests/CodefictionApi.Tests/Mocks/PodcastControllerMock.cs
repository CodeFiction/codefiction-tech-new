using Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers;
using CodefictionApi.Core.Contracts;
using Moq;

namespace CodefictionApi.Tests.Mocks
{
    public class PodcastControllerMock : PodcastController
    {
        private PodcastControllerMock(Mock<IPodcastService> podcastService)
            : base(podcastService.Object)
        {
            PodcastService = podcastService;
        }

        public Mock<IPodcastService> PodcastService { get; set; }

        public static PodcastControllerMock Create()
        {
            return new PodcastControllerMock(new Mock<IPodcastService>(MockBehavior.Strict));
        }
    }
}