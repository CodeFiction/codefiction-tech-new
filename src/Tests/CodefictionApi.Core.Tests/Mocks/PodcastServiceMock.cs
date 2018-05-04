using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Services;
using Moq;

namespace CodefictionApi.Core.Tests.Mocks
{
    public class PodcastServiceMock : PodcastService
    {
        private PodcastServiceMock(Mock<IPodcastRepository> podcastRepository, Mock<IPodcastModelMapper> podcastModelMapper)
            : base(podcastRepository.Object, podcastModelMapper.Object)
        {
            PodcastRepository = podcastRepository;
            PodcastModelMapper = podcastModelMapper;
        }

        public Mock<IPodcastRepository> PodcastRepository { get; set; }

        public Mock<IPodcastModelMapper> PodcastModelMapper { get; set; }

        public static PodcastServiceMock Create()
        {
            return new PodcastServiceMock(new Mock<IPodcastRepository>(MockBehavior.Strict),
                                          new Mock<IPodcastModelMapper>(MockBehavior.Strict));
        }
    }
}