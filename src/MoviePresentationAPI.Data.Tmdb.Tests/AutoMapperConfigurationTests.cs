using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MoviePresentationAPI.Data.Tmdb.Tests
{
    [TestClass]
    public class AutoMapperConfigurationTests
    {
        [TestMethod]
        public void TestTmdbLibToEntitiesMapping()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<TmdbMovieTranslatorProfile>());
            config.AssertConfigurationIsValid();
        }
    }
}
