using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoviePresentationAPI.Data.Tmdb;
using MoviePresentationAPI.Services;
using MoviePresentationAPI.Tests.TestData;
using System.Threading.Tasks;

namespace MoviePresentationAPI.Tests.Services
{
    public class ListMoviesScenarioServiceTests
    {
        internal IListMoviesScenarioService _service;
        internal Mock<ITheMovieDatabaseClient> _clientMock;

        internal void InitMocks()
        {
            _clientMock = new Mock<ITheMovieDatabaseClient>();

            _clientMock.Setup(c => c.GetMovieNowPlayingListAsync(MovieData.moviesRequestPage))
                .Returns(Task.FromResult(MovieData.SearchMovieResults));
            _clientMock.Setup(c => c.GetMovieTopRatedListAsync(MovieData.moviesRequestPage))
                .Returns(Task.FromResult(MovieData.SearchMovieResults));
            _clientMock.Setup(c => c.GetMovieUpcomingListAsync(MovieData.moviesRequestPage))
                .Returns(Task.FromResult(MovieData.SearchMovieResults));
        }

        [TestMethod]
        public void TestGetMovies()
        {
            var result = _service.ListMoviesAsync(MovieData.moviesRequestPage).Result;

            Assert.AreEqual(MovieData.SearchMovieResults, result);
        }

    }
}
