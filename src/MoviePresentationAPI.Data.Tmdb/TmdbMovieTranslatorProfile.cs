using AutoMapper;
using MoviePresentationAPI.Entities;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace MoviePresentationAPI.Data.Tmdb
{
    public class TmdbMovieTranslatorProfile : Profile
    {
        public TmdbMovieTranslatorProfile()
        {
            CreateMap<SearchMovie, MovieEntity>();
            CreateMap<SearchContainer<SearchMovie>, SearchContainerEntity<MovieEntity>>();
        }
    }
}
