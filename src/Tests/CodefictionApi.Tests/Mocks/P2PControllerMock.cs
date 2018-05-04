using Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers;
using CodefictionApi.Core.Contracts;
using Moq;

namespace CodefictionApi.Tests.Mocks
{
    public class P2PControllerMock : P2PController
    {
        private P2PControllerMock(Mock<IPodcastService> podcastService)
            : base(podcastService.Object)
        {
            PodcastService = podcastService;
        }

        public Mock<IPodcastService> PodcastService { get; set; }

        public static P2PControllerMock Create()
        {
            return new P2PControllerMock(new Mock<IPodcastService>(MockBehavior.Strict));
        }
    }
}