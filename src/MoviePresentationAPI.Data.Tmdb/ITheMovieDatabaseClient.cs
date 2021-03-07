using MoviePresentationAPI.Entities;
using System.Threading.Tasks;

namespace MoviePresentationAPI.Data.Tmdb
{
    public interface ITheMovieDatabaseClient
    {
        Task<SearchContainerEntity<MovieEntity>> GetMovieNowPlayingListAsync(int page = 0);
        Task<SearchContainerEntity<MovieEntity>> GetMovieUpcomingListAsync(int page = 0);
        Task<SearchContainerEntity<MovieEntity>> GetMovieTopRatedListAsync(int page = 0);
    }
}
