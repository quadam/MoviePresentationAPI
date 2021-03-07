using MoviePresentationAPI.Models;

namespace MoviePresentationAPI.Services
{
    public interface IListMoviesScenarioServiceFactory
    {
        IListMoviesScenarioService GetListMoviesService(MovieScenario scenario);
    }
}
