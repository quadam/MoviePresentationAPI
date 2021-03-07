using MoviePresentationAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviePresentationAPI.InquiryProcessing
{
    public interface IMoviesInquiryProcessor
    {
        Task<PagedDataResponse<IEnumerable<Movie>>> GetMovies(MoviesRequest request);
    }
}
