using AutoMapper;
using MoviePresentationAPI.Models;
using MoviePresentationAPI.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviePresentationAPI.InquiryProcessing
{
    public class MoviesInquiryProcessor : IMoviesInquiryProcessor
    {
        private readonly IMapper _mapper;
        private readonly IListMoviesScenarioServiceFactory _listMoviesServiceFactory;

        public MoviesInquiryProcessor(IMapper mapper, IListMoviesScenarioServiceFactory listMoviesServiceFactory)
        {
            _mapper = mapper;
            _listMoviesServiceFactory = listMoviesServiceFactory;
        }

        public async Task<PagedDataResponse<IEnumerable<Movie>>> GetMovies(MoviesRequest request)
        {
            var listMoviesService = _listMoviesServiceFactory.GetListMoviesService(request.Scenario);

            if (listMoviesService == null)
            {
                throw new NotImplementedException();
            }

            var movies = await listMoviesService.ListMoviesAsync(page: request.PageNumber);
            var response = _mapper.Map<PagedDataResponse<IEnumerable<Movie>>>(movies);
            response.PageSize = 20;

            return response;
        }
    }
}
