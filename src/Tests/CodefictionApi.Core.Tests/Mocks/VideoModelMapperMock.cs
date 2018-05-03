using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Services.Mappers;
using Moq;

namespace CodefictionApi.Core.Tests.Mocks
{
    public class VideoModelMapperMock : VideoModelMapper
    {
        private VideoModelMapperMock(Mock<IPersonService> personService)
            : base(personService.Object)
        {
            PersonService = personService;
        }

        public Mock<IPersonService> PersonService { get; set; }

        public static VideoModelMapperMock Create()
        {
            return new VideoModelMapperMock(new Mock<IPersonService>(MockBehavior.Strict));
        }
    }
}