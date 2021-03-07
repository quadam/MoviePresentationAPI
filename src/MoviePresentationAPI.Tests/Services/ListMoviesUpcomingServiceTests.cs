using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviePresentationAPI.Services;

namespace MoviePresentationAPI.Tests.Services
{
    [TestClass]
    public class ListMoviesUpcomingServiceTests : ListMoviesScenarioServiceTests
    {
        [TestInitialize]
        public void Init()
        {
            InitMocks();

            _service = new ListMoviesUpcomingService(_clientMock.Object);
        }
    }
}
