using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Services.api.BookStore.Core.Context
{
    public class MongoDb : IMongoDb
    {
        private readonly IMongoDatabase _db;
        public MongoDb(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoDatabase GetDatabase()
        {
            return _db;
        }
    }
}