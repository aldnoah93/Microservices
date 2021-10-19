using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.api.BookStore.Core.Entities
{
    [BsonCollectionAtribute(collectionName:"Book")]
    public class Book : Document
    {
        [BsonElement("Title")]
        public String Title { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Price")]
        public long Price { get; set; }
        [BsonElement("PublishDate")]
        public DateTime? PublishDate { get; set; }
        [BsonElement("Author")]
        public Author Author { get; set; }
    }
}