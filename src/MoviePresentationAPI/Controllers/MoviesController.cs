using Microsoft.AspNetCore.Mvc;
using MoviePresentationAPI.InquiryProcessing;
using MoviePresentationAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviePresentationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMoviesInquiryProcessor _moviesInquiryProcessor;

        public MoviesController(IMoviesInquiryProcessor moviesInquiryProcessor)
        {
            _moviesInquiryProcessor = moviesInquiryProcessor;
        }

        [HttpGet]
        public async Task<PagedDataResponse<IEnumerable<Movie>>> Get([FromQuery] MoviesRequest request)
        {
            return await _moviesInquiryProcessor.GetMovies(request);
        }
    }
}
