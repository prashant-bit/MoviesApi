using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Try2_mongo.Models
{
    public class Movies
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        public decimal Budget { get; set; }


        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string DirectorId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]

        public List<string> ActorId { get; set; }

        public List<Actors> Actors { get; set; }
    }
}
