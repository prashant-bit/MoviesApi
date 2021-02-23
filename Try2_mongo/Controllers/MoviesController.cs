using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try2_mongo.Models;
using Try2_mongo.Services;

namespace Try2_mongo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly MoviesServices _movieService;

        public MoviesController(MoviesServices movieService)
        {
            _movieService = movieService;
        }


        
        public async Task<ActionResult<List<Movies>>> Get() =>
            await _movieService.GetAsync();

        [HttpGet]
        public async Task<ActionResult<List<Movies>>> GetAgre() =>
            await _movieService.GetAgre();

        [HttpGet("{id:length(24)}", Name = "GetMovie")]
        public ActionResult<Movies> Get(string id)
        {
            var movie = _movieService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]

        public async Task<IActionResult> Create(Movies movie)
        {
            _movieService.CreateAsync(movie);
            return NoContent();
        }
    }
}
