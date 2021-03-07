using AutoMapper;
using MoviePresentationAPI.Entities;
using MoviePresentationAPI.Models;
using System.Collections.Generic;

namespace MoviePresentationAPI
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieEntity, Movie>();
            CreateMap<SearchContainerEntity<MovieEntity>, PagedDataResponse<IEnumerable<Movie>>>()
                .ForMember(pdr => pdr.PageNumber, opt => opt.MapFrom(sce => sce.Page))
                .ForMember(pdr => pdr.PageSize, opts => opts.Ignore());
        }
    }
}
