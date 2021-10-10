using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Services.api.BookStore.Core.Context;
using Services.api.BookStore.Core.Entities;

namespace Services.api.BookStore.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IAuthorContext _context;
        public AuthorRepository(IAuthorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            var authors = await  _context.GetCollection().Find<Author>(FilterDefinition<Author>.Empty).ToListAsync();
            return authors;
        }
    }
}