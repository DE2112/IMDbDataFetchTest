using System.Linq;
using System.Threading.Tasks;
using IMDbApiLib;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Models;

namespace TestWebApp.Utilities
{
    public class IMDBApiAdapter
    {
        private ApiLib _imdbApi;

        public IMDBApiAdapter()
        {
            _imdbApi = new ApiLib("k_f5mkyja4");
        }

        public async Task<ActionResult<Movie[]>> GetMoviesOnPage(int page)
        {
            var movies = await _imdbApi.MostPopularMoviesAsync();
            var moviesOnPage = movies.Items.Page(10, 1).ToArray();

            var result = Enumerable.Range(0, 10).Select(index => new Movie(moviesOnPage[index])).ToArray();
            return new JsonResult(result);
        }
    }
}