using MongoDB.Driver;
using Services.api.BookStore.Core.Entities;

namespace Services.api.BookStore.Core.Context
{
    public interface IAuthorContext
    {
        public IMongoCollection<Author> GetCollection();
    }
}