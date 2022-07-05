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
        private readonly IMDBApiAdapter _imdbApiAdapter;

        public DataFetchController(ILogger<DataFetchController> logger)
        {
            _logger = logger;
            _imdbApiAdapter = new IMDBApiAdapter();
        }

        [HttpGet]
        public async Task<ActionResult<Movie[]>> Get()
        {
            return await _imdbApiAdapter.GetMoviesOnPage(1);
        }
    }
}