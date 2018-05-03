using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Services;
using Moq;

namespace CodefictionApi.Core.Tests.Mocks
{
    public class PodcastServiceMock : PodcastService
    {
        private PodcastServiceMock(IMock<IPodcastRepository> podcastRepository, IMock<IPodcastModelMapper> podcastModelMapper)
            : base(podcastRepository.Object, podcastModelMapper.Object)
        {
            PodcastRepository = podcastRepository;
            PodcastModelMapper = podcastModelMapper;
        }

        public IMock<IPodcastRepository> PodcastRepository { get; set; }

        public IMock<IPodcastModelMapper> PodcastModelMapper { get; set; }

        public static PodcastServiceMock Create()
        {
            return new PodcastServiceMock(new Mock<IPodcastRepository>(MockBehavior.Strict),
                                          new Mock<IPodcastModelMapper>(MockBehavior.Strict));
        }
    }
}