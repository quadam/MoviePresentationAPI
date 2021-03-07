using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoviePresentationAPI.Models;
using MoviePresentationAPI.Services;
using System;
using System.Collections.Generic;

namespace MoviePresentationAPI.Tests.Services
{
    [TestClass]
    public class ListMoviesScenarioServiceFactoryTests
    {
        [TestMethod]
        public void TestCreateService()
        {
            var serviceProviderMock = new Mock<IServiceProvider>();
            var listMovieScenarioMock = new Mock<IListMoviesScenarioService>();

            serviceProviderMock.Setup(sp => sp.GetService(listMovieScenarioMock.Object.GetType()))
                .Returns(listMovieScenarioMock.Object);

            Dictionary<MovieScenario, Type> lookup = new Dictionary<MovieScenario, Type>
            {
                { MovieScenario.NowPlaying, listMovieScenarioMock.Object.GetType() }
            };

            var factory = new ListMoviesScenarioServiceFactory(serviceProviderMock.Object, lookup);

            var service = factory.GetListMoviesService(MovieScenario.NowPlaying);

            Assert.AreEqual(listMovieScenarioMock.Object.GetType(), service.GetType());
        }
    }
}
