using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Try2_mongo.Models;

namespace Try2_mongo.Services
{
    public static class CommonServices
    {

        public static void RegisterMongoDbRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IMongoClient, MongoClient>(s =>
            {
                var uri = s.GetRequiredService<IConfiguration>()["MongoUri"];
                return new MongoClient(uri);
            });
            services.AddSingleton<MoviesServices>();
            services.AddSingleton<ActorsServices>();
            services.AddSingleton<DirectorsServices>();
        }
    }
}
