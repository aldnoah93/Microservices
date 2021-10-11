using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Services.api.BookStore.Core.Context;
using Services.api.BookStore.Core.Entities;

namespace Services.api.BookStore.Repository
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;
        public MongoRepository(IMongoDb mongoDb)
        {
            _collection = mongoDb.GetDatabase().GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType){
            return ((BsonCollectionAtribute)documentType.GetCustomAttributes(typeof(BsonCollectionAtribute), true).FirstOrDefault()).CollectionName;
        }
        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            var documents = await _collection.Find(FilterDefinition<TDocument>.Empty).ToListAsync();
            return documents;
        }

        public async Task<TDocument> GetByIdAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc=>doc.Id, id);
            var document = await _collection.Find(filter).SingleOrDefaultAsync();
            return document;
        }

        public async Task InsertAsync(TDocument document)
        {
           await _collection.InsertOneAsync(document);
        }

        public async Task UpdateAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc=>doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc=>doc.Id, id);
            await _collection.FindOneAndDeleteAsync(filter);

        }
    }
}