using Codefiction.CodefictionTech.CodefictionApi.Server.ApiControllers;
using CodefictionApi.Core.Contracts;
using Moq;

namespace CodefictionApi.Tests.Mocks
{
    public class PersonControllerMock : PersonController
    {
        private PersonControllerMock(Mock<IPersonService> personService)
            : base(personService.Object)
        {
            PersonService = personService;
        }

        public Mock<IPersonService> PersonService { get; set; }

        public static PersonControllerMock Create()
        {
            return new PersonControllerMock(new Mock<IPersonService>(MockBehavior.Strict));
        }
    }
}