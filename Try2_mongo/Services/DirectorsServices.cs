using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Try2_mongo.Models;

namespace Try2_mongo.Services
{
    public class DirectorsServices
    {

        private readonly IMongoCollection<Directors> _directors;
        private readonly IMongoClient _mongoClient;

        public DirectorsServices(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            _directors = mongoClient.GetDatabase("MovieDb").GetCollection<Directors>("Director");
        }

        public List<Directors> Get() =>
            _directors.Find(dir => true).ToList();

        public Directors Get(string id) =>
            _directors.Find<Directors>(dir => dir.Id == id).FirstOrDefault();

        public Directors Create(Directors director)
        {
            _directors.InsertOne(director);
            return director;
        }
    }
}
