using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviePresentationAPI.Services;

namespace MoviePresentationAPI.Tests.Services
{
    [TestClass]
    public class ListMoviesNowPlayingServiceTests : ListMoviesScenarioServiceTests
    {
        [TestInitialize]
        public void Init()
        {
            InitMocks();

            _service = new ListMoviesNowPlayingService(_clientMock.Object);
        }
    }
}
