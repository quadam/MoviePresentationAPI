namespace MoviePresentationAPI.Models
{
    public class PagedDataResponse<T>
    {
        public T Results { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}
