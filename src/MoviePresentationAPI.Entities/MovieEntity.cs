using System;
using System.Collections.Generic;

namespace MoviePresentationAPI.Entities
{
    public class MovieEntity
    {
        public bool Adult { get; set; }
        public string OriginalTitle { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public string BackdropPath { get; set; }
        public List<int> GenreIds { get; set; }
        public string OriginalLanguage { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public int Id { get; set; }
        public MediaType MediaType { get; set; }
        public double Popularity { get; set; }
    }
}
