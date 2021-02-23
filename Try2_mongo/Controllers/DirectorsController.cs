using Microsoft.AspNetCore.Mvc;
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
    public class DirectorsController : Controller
    {
        private readonly DirectorsServices _directorService;

        public DirectorsController(DirectorsServices directorService)
        {
            _directorService = directorService;
        }

        [HttpGet]
        public ActionResult<List<Directors>> Get() =>
            _directorService.Get();

        [HttpGet("{id:length(24)}", Name = "GetDirector")]
        public ActionResult<Directors> Get(string id)
        {
            var dir = _directorService.Get(id);

            if (dir == null)
            {
                return NotFound();
            }

            return dir;
        }
    }
}
