using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoviePresentationAPI.Models
{
    public class MoviesRequest
    {
        public int PageNumber { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MovieScenario Scenario { get; set; }
    }
}
