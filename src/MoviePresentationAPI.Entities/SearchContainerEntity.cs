using System.Collections.Generic;

namespace MoviePresentationAPI.Entities
{
    public class SearchContainerEntity<T>
    {
        public int Page { get; set; }
        public List<T> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
