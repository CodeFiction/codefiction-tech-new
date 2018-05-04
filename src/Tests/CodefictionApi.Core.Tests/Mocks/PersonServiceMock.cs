using CodefictionApi.Core.Contracts;
using CodefictionApi.Core.Services;
using Moq;

namespace CodefictionApi.Core.Tests.Mocks
{
    public class PersonServiceMock : PersonService
    {
        private PersonServiceMock(Mock<IPersonRepository> personRepository)
            : base(personRepository.Object)
        {
            PersonRepository = personRepository;
        }

        public Mock<IPersonRepository> PersonRepository { get; set; }


        public static PersonServiceMock Create()
        {
            return new PersonServiceMock(new Mock<IPersonRepository>(MockBehavior.Strict));
        }
    }
}