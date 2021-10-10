using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.api.BookStore.Core.Entities;

namespace Services.api.BookStore.Core.Context
{
    public class AuthorContext : IAuthorContext
    {
        private readonly IMongoDatabase _db;
        public AuthorContext(IOptions<MongoSettings> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Author> GetCollection()
        {
            return _db.GetCollection<Author>("Author");
        }
    }
}