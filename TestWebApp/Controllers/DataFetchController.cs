using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDbApiLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWebApp.Models;
using TestWebApp.Utilities;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataFetchController
    {

        private readonly ILogger<DataFetchController> _logger;
        private readonly IMDbApiAdapter _imDbApiAdapter;

        public DataFetchController(ILogger<DataFetchController> logger)
        {
            _logger = logger;
            _imDbApiAdapter = new IMDbApiAdapter();
        }

        [HttpGet("{page}/{pageSize}")]
        public async Task<ActionResult<object>> GetMovies(int page, int pageSize)
        {
            return await _imDbApiAdapter.GetMoviesOnPageAsync(page, pageSize);
        }

        [HttpGet("{expression}")]
        public async Task<ActionResult<Movie?>> GetMovie(string expression)
        {
            return await _imDbApiAdapter.GetMovieByTitle(expression);
        }
    }
}