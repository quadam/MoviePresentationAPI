using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoviePresentationAPI.Tests
{
    [TestClass]
    public class MovieProfileTests
    {
        [TestMethod]
        public void TestAutomapperMovieProfile()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MovieProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}
