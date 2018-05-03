using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Services.Mappers;
using Moq;

namespace CodefictionApi.Core.Tests.Mocks
{
    public class PodcastModelMapperMock : PodcastModelMapper
    {
        private PodcastModelMapperMock(Mock<IPersonService> personService) 
            : base(personService.Object)
        {
            PersonService = personService;
        }

        public Mock<IPersonService> PersonService { get; set; }

        public static PodcastModelMapperMock Create()
        {
            return new PodcastModelMapperMock(new Mock<IPersonService>(MockBehavior.Strict));
        }
    }
}