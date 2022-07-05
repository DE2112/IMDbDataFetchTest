using IMDbApiLib.Models;

namespace TestWebApp.Models
{
    public class Movie
    {
        public string Title { get; set; }
        //public string Description { get; set; }
        public string ImageLink { get; set; }
        public string Rating { get; set; }

        public Movie(TitleData titleData)
        {
            Title = titleData.Title;
            //Description = titleData.Plot;
            ImageLink = titleData.Image;
            Rating = titleData.IMDbRating;
        }

        public Movie(MostPopularDataDetail data)
        {
            Title = data.Title;
            ImageLink = data.Image;
            Rating = data.IMDbRating;
        }
    }
}