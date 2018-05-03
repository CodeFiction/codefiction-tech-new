using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Services;
using Moq;

namespace CodefictionApi.Core.Tests.Mocks
{
    public class VideoServiceMock : VideoService
    {
        private VideoServiceMock(IMock<IVideoRepository> videoRepository, IMock<IVideoModelMapper> videoModelMapper)
            : base(videoRepository.Object, videoModelMapper.Object)
        {
            VideoRepository = videoRepository;
            VideoModelMapper = videoModelMapper;
        }

        public IMock<IVideoRepository> VideoRepository { get; set; }

        public IMock<IVideoModelMapper> VideoModelMapper { get; set; }

        public static VideoServiceMock Create()
        {
            return new VideoServiceMock(new Mock<IVideoRepository>(MockBehavior.Strict),
                                        new Mock<IVideoModelMapper>(MockBehavior.Strict));
        }
    }
}