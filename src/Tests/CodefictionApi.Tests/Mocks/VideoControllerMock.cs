using Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers;
using CodefictionApi.Core.Contracts;
using Moq;

namespace CodefictionApi.Tests.Mocks
{
    public class VideoControllerMock : VideoController
    {
        private VideoControllerMock(Mock<IVideoService> videoService)
            : base(videoService.Object)
        {
            VideoService = videoService;
        }

        public Mock<IVideoService> VideoService { get; set; }

        public static VideoControllerMock Create()
        {
            return new VideoControllerMock(new Mock<IVideoService>(MockBehavior.Strict));
        }
    }
}