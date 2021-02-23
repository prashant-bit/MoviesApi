using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try2_mongo.Models;

namespace Try2_mongo.Services
{

    public class MoviesServices
    {
        private readonly IMongoCollection<Movies> _movies;
        private readonly IMongoCollection<Actors> _actors;
        private readonly IMongoClient _mongoClient;

        public MoviesServices(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            _movies = mongoClient.GetDatabase("MovieDb").GetCollection<Movies>("Movies");
            _actors = mongoClient.GetDatabase("MovieDb").GetCollection<Actors>("Actors");
        }

        public async Task<List<Movies>> GetAsync() =>
            await _movies.Find(movie => true).ToListAsync();

        public async Task<List<Movies>> GetAgre()
        {
            var projectionFilter = Builders<Movies>.Projection
               .Include(m => m.Name)
               .Include(m => m.Budget)
               .Include(m => m.Actors)
               .Exclude(m => m.Id);
            var movies = _movies
                .Aggregate()
                .Lookup(
                    _actors,
                    m => m.ActorId,
                    c => c.Id,
                    (Movies m) => m.Actors
                )
                .Project<Movies>(projectionFilter)
                .ToListAsync();
            return await movies;
        }

        public Movies Get(string id)
        {
            var projectionFilter = Builders<Movies>.Projection
               .Include(m => m.Name)
               .Include(m => m.Budget)
               .Include(m => m.Actors)
               .Exclude(m => m.Id);
            var movies = _movies
                .Aggregate()
                .Match(Builders<Movies>.Filter.Eq(m => m.Id,
                                             id))
                .Lookup(
                    _actors,
                    m => m.ActorId,
                    c => c.Id,
                    (Movies m) => m.Actors
                ).ToList();
            return movies.FirstOrDefault();
        }
        
        public void CreateAsync(Movies movie)
        {
             _movies.InsertOne(movie);
            //return book;
        }

        public void Update(string id, Movies movieIn) =>
            _movies.ReplaceOne(movie => movie.Id == id, movieIn);

        public void Remove(Movies movieIn) =>
            _movies.DeleteOne(movie => movie.Id == movieIn.Id);

        public void Remove(string id) =>
            _movies.DeleteOne(movie => movie.Id == id);
        
    }
}

