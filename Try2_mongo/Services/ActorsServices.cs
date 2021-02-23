using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Try2_mongo.Models;

namespace Try2_mongo.Services
{
    public class ActorsServices
    {
        private readonly IMongoCollection<Actors> _movies;
        private readonly IMongoClient _mongoClient;

        public ActorsServices(IMongoClient mongoClient)
        {

            _mongoClient = mongoClient;
            _movies = mongoClient.GetDatabase("MovieDb").GetCollection<Actors>("Actors");
        }

        public List<Actors> Get() =>
            _movies.Find(actor => true).ToList();

        public Actors Get(string id) =>
            _movies.Find<Actors>(actor => actor.Id == id).FirstOrDefault();

        public Actors Create(Actors actor)
        {
            _movies.InsertOne(actor);
            return actor;
        }

    }
}
