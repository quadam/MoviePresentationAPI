using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoviePresentationAPI.InquiryProcessing;
using MoviePresentationAPI.Models;
using MoviePresentationAPI.Services;
using MoviePresentationAPI.Tests.TestData;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviePresentationAPI.Tests.InquiryProcessing
{
    [TestClass]
    public class MoviesInquiryProcessorTests
    {
        [TestMethod]
        public void TestGetMovies()
        {
            var mapperMock = new Mock<IMapper>();
            var listMoviesServiceFactory = new Mock<IListMoviesScenarioServiceFactory>();
            var listMoviesService = new Mock<IListMoviesScenarioService>();

            var movies = MovieData.SearchMovieResults;
            var pagedDataResponse = MovieData.pagedDataResponse;
            var request = MovieData.moviesRequest;

            mapperMock.Setup(m => m.Map<PagedDataResponse<IEnumerable<Movie>>>(movies))
                .Returns(pagedDataResponse);

            listMoviesService.Setup(s => s.ListMoviesAsync(request.PageNumber))
                .Returns(Task.FromResult(movies));

            listMoviesServiceFactory.Setup(f => f.GetListMoviesService(request.Scenario))
                .Returns(listMoviesService.Object);

            var inquiryProcessor = new MoviesInquiryProcessor(mapperMock.Object, listMoviesServiceFactory.Object);
            var processorResponse = inquiryProcessor.GetMovies(request).Result;

            Assert.AreEqual(pagedDataResponse, processorResponse);
        }
    }
}
