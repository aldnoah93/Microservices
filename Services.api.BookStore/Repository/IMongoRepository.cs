using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.api.BookStore.Core.Entities;

namespace Services.api.BookStore.Repository
{
    public interface IMongoRepository<TDocument> where TDocument : IDocument
    {
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<TDocument> GetByIdAsync(string id);
        Task InsertAsync(TDocument document);
        Task UpdateAsync(TDocument document);
        Task DeleteByIdAsync(string id);
    }
}