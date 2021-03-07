using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviePresentationAPI.Services;

namespace MoviePresentationAPI.Tests.Services
{
    [TestClass]
    public class ListMoviesTopRatedServiceTests : ListMoviesScenarioServiceTests
    {
        [TestInitialize]
        public void Init()
        {
            InitMocks();

            _service = new ListMoviesTopRatedService(_clientMock.Object);
        }
    }
}
