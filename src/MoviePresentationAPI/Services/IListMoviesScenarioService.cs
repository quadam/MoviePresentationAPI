using MoviePresentationAPI.Entities;
using System.Threading.Tasks;

namespace MoviePresentationAPI.Services
{
    public interface IListMoviesScenarioService
    {
        Task<SearchContainerEntity<MovieEntity>> ListMoviesAsync(int page);
    }
}
