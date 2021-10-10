using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Services.api.BookStore.Core.Entities;

namespace Services.api.BookStore.Core.Context
{
    public class AuthorContext : IAuthorContext
    {
        private readonly IMongoDatabase _db;
        public AuthorContext(IMongoDb mongoDb)
        {
            _db = mongoDb.GetDatabase();
        }
        public IMongoCollection<Author> GetCollection()
        {
            return _db.GetCollection<Author>("Author");
        }
    }
}