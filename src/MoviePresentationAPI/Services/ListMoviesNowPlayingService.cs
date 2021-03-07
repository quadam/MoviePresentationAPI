using MoviePresentationAPI.Data.Tmdb;
using MoviePresentationAPI.Entities;
using System.Threading.Tasks;

namespace MoviePresentationAPI.Services
{
    public class ListMoviesNowPlayingService : IListMoviesScenarioService
    {
        private readonly ITheMovieDatabaseClient _theMovieDatabaseClient;

        public ListMoviesNowPlayingService(ITheMovieDatabaseClient theMovieDatabaseClient)
        {
            _theMovieDatabaseClient = theMovieDatabaseClient;
        }

        public async Task<SearchContainerEntity<MovieEntity>> ListMoviesAsync(int page)
        {
            return await _theMovieDatabaseClient.GetMovieNowPlayingListAsync(page: page);
        }
    }
}
