using MoviePresentationAPI.Entities;
using MoviePresentationAPI.Models;
using System.Collections.Generic;

namespace MoviePresentationAPI.Tests.TestData
{
    public static class MovieData
    {
        public const int moviesRequestPage = 6;
        public const int moviesPageSize = 20;
        public const int moviesTotalPages = 100;
        public const int moviesTotalResults = 2000;

        public static readonly MoviesRequest moviesRequest =
            new MoviesRequest()
            {
                PageNumber = moviesRequestPage,
                Scenario = MovieScenario.NowPlaying
            };

        public static readonly PagedDataResponse<IEnumerable<Movie>> pagedDataResponse =
            new PagedDataResponse<IEnumerable<Movie>>
            {
                PageNumber = moviesRequest.PageNumber,
                PageSize = moviesPageSize,
                Results = new List<Movie>
                {
                    new Movie
                    {
                        Adult = false,
                        VoteAverage = 5,
                        GenreIds = new List<int>{ 3, 6, 8 }
                    }
                },
                TotalPages = moviesTotalPages
            };

        public static readonly SearchContainerEntity<MovieEntity> SearchMovieResults =
            new SearchContainerEntity<MovieEntity>
            {
                Page = moviesRequestPage,
                Results = new List<MovieEntity>
                {
                    new MovieEntity
                    {
                        Adult = false,
                        Id = 3,
                        VoteAverage = 6
                    }
                },
                TotalPages = moviesTotalPages,
                TotalResults = moviesTotalResults
            };
    }
}
