using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IMDbApiLib;
using IMDbApiLib.Models;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Models;
using System.Text.Json;

namespace TestWebApp.Utilities
{
    public class IMDbApiAdapter
    {
        private ApiLib _imdbApi;
        private HttpClient _httpClient;

        public IMDbApiAdapter()
        {
            _imdbApi = new ApiLib("k_56ariphs");
            _httpClient = new HttpClient();
        }

        private async Task<Movie?> SearchMovieAsync(string expression, bool isImdbId)
        {
            //The reason why I'm using OMDb API here instead of IMDb API is the limit of 100 API calls in IMDb's one
            //that made me register MORE THAN 5 DIFFERENT API KEYS for today only.
            //I could've been using OMDb API only, but there's no such feature allowing me to get the most popular movies list in it.
            var url = $"http://www.omdbapi.com/?i={expression}&apikey=f38dc567";
            if (!isImdbId)
            {
                url = $"http://www.omdbapi.com/?t={expression}&apikey=f38dc567";
            }
            
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStreamAsync();
                return JsonSerializer.Deserialize<Movie>(responseContent,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return null;
        }

        public async Task<ActionResult<object>> GetMoviesOnPageAsync(int page, int pageSize)
        {
            var mostPopularMoviesData = await _imdbApi.MostPopularMoviesAsync();
            var moviesOnPage = mostPopularMoviesData.Items.Page(page, pageSize)
                .Select(async detail => await SearchMovieAsync(detail.Id, true))
                .Select(task => task.Result).ToArray();
            
            return new JsonResult(new { Count = mostPopularMoviesData.Items.Count, Movies = moviesOnPage });
        }

        public async Task<ActionResult<Movie?>> GetMovieByTitle(string expression)
        {
            var movie = await SearchMovieAsync(expression, false);
            
            return new JsonResult(movie);
        }
    }
}