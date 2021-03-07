using AutoMapper;
using MoviePresentationAPI.Entities;
using System.Threading.Tasks;
using TMDbLib.Client;

namespace MoviePresentationAPI.Data.Tmdb
{
    public class TheMovieDatabaseClient : ITheMovieDatabaseClient
    {
        private readonly TMDbClient _tMDbClient;
        private readonly IMapper _mapper;

        public TheMovieDatabaseClient(TMDbClient tMDbClient, IMapper mapper)
        {
            _tMDbClient = tMDbClient;
            _mapper = mapper;
        }

        public async Task<SearchContainerEntity<MovieEntity>> GetMovieNowPlayingListAsync(int page = 0)
        {
            var searchContainer = await _tMDbClient.GetMovieNowPlayingListAsync(page: page);

            var searchContainerEntity = _mapper.Map<SearchContainerEntity<MovieEntity>>(searchContainer);

            return searchContainerEntity;
        }

        public async Task<SearchContainerEntity<MovieEntity>> GetMovieTopRatedListAsync(int page = 0)
        {
            var searchContainer = await _tMDbClient.GetMovieTopRatedListAsync(page: page);

            var searchContainerEntity = _mapper.Map<SearchContainerEntity<MovieEntity>>(searchContainer);

            return searchContainerEntity;
        }

        public async Task<SearchContainerEntity<MovieEntity>> GetMovieUpcomingListAsync(int page = 0)
        {
            var searchContainer = await _tMDbClient.GetMovieUpcomingListAsync(page: page);

            var searchContainerEntity = _mapper.Map<SearchContainerEntity<MovieEntity>>(searchContainer);

            return searchContainerEntity;
        }
    }
}
