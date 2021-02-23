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
    public class ActorsController : Controller
    {
        private readonly ActorsServices _actorService;

        public ActorsController(ActorsServices actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public ActionResult<List<Actors>> Get() =>
            _actorService.Get();

        [HttpGet("{id:length(24)}", Name = "GetActor")]
        public ActionResult<Actors> Get(string id)
        {
            var actor = _actorService.Get(id);

            if (actor == null)
            {
                return NotFound();
            }

            return actor;
        }

    }
}
