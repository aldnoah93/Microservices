using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
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

        public async Task<PaginationEntity<TDocument>> PaginationByAsync(Expression<Func<TDocument, bool>> filterExpression, PaginationEntity<TDocument> pagination)
        {
            var sort = pagination.SortDirection == "desc" ? 
                Builders<TDocument>.Sort.Descending(pagination.Sort) : 
                Builders<TDocument>.Sort.Ascending(pagination.Sort);
            
            var filter = string.IsNullOrEmpty(pagination.Filter) ? FilterDefinition<TDocument>.Empty : filterExpression;

            var pageSize = pagination.PageSize == 0 ? 1 : pagination.PageSize;
            var page = pagination.Page == 0 ? 1 : pagination.Page;
            pagination.Data = await _collection.Find(filter)
                    .Sort(sort)
                    .Skip((page - 1) * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();

            long totalDocuments = await _collection.CountDocumentsAsync(filter);
            int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalDocuments) / Convert.ToDouble(pageSize)));

            pagination.PagesQuantity = totalPages;

            return pagination;

        }

        public async Task<PaginationEntity<TDocument>> PaginationByFilterAsync(PaginationEntity<TDocument> pagination)
        {
            var sort = pagination.SortDirection == "desc" ? 
                Builders<TDocument>.Sort.Descending(pagination.Sort) : 
                Builders<TDocument>.Sort.Ascending(pagination.Sort);
            
            var filter = pagination.FilterValue == null ? 
                FilterDefinition<TDocument>.Empty : 
                Builders<TDocument>.Filter.Regex(pagination.FilterValue.Property, new BsonRegularExpression($".*{pagination.FilterValue.Value}.*", "i"));

            var pageSize = pagination.PageSize == 0 ? 1 : pagination.PageSize;
            var page = pagination.Page == 0 ? 1 : pagination.Page;
            pagination.Data = await _collection.Find(filter)
                    .Sort(sort)
                    .Skip((page - 1) * pageSize)
                    .Limit(pageSize)
                    .ToListAsync();

            long totalDocuments = await _collection.CountDocumentsAsync(filter);
            int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(totalDocuments) / Convert.ToDouble(pageSize)));

            pagination.PagesQuantity = totalPages;
            pagination.DocumentsTotal = totalDocuments;

            return pagination;
        }
    }
}