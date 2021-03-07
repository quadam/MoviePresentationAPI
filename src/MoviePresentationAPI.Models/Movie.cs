using System;
using System.Collections.Generic;

namespace MoviePresentationAPI.Models
{
    public class Movie
    {
        public string OriginalTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Adult { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public long Id { get; set; }
        public int MediaType { get; set; }
        public double Popularity { get; set; }
        public List<int> GenreIds { get; set; }
    }
}
