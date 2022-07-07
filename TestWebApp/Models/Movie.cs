using System.Linq;
using IMDbApiLib.Models;

namespace TestWebApp.Models
{
    public class Movie
    {
        public string? Title { get; set; }
        public string? Poster { get; set; }
        public string? Plot { get; set; }
        public string? Released { get; set; }
        public string? Actors { get; set; }
        public string? Country { get; set; }
        public string? Director { get; set; }
        public string? Writer { get; set; }
        public string? ImdbRating { get; set; }
    }
}