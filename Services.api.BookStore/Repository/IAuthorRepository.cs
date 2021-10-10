using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.api.BookStore.Core.Entities;

namespace Services.api.BookStore.Repository
{
    public interface IAuthorRepository
    {
        public Task<IEnumerable<Author>> GetAuthorsAsync();
    }
}