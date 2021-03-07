using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoviePresentationAPI.Controllers;
using MoviePresentationAPI.InquiryProcessing;
using MoviePresentationAPI.Tests.TestData;
using System.Threading.Tasks;

namespace MoviePresentationAPI.Tests.Controllers
{
    [TestClass]
    public class MoviesControllerTests
    {
        [TestMethod]
        public void TestGetMovies()
        {
            var inquiryProcessorMock = new Mock<IMoviesInquiryProcessor>();

            var request = MovieData.moviesRequest;

            var response = MovieData.pagedDataResponse;

            inquiryProcessorMock.Setup(p => p.GetMovies(request))
                .Returns(Task.FromResult(response));

            var controller = new MoviesController(inquiryProcessorMock.Object);

            var controllerResponse = controller.Get(request).Result;

            Assert.AreEqual(response, controllerResponse);

            Assert.AreEqual(response.PageNumber, controllerResponse.PageNumber);
        }
    }
}
