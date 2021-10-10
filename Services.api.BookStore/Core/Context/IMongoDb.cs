using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Services.api.BookStore.Core.Context
{
    public interface IMongoDb
    {
        public IMongoDatabase GetDatabase();
    }
}