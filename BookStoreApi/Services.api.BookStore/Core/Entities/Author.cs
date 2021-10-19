using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Services.api.BookStore.Core.Entities
{
    [BsonCollectionAtribute(collectionName:"Author")]
    public class Author : Document
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("lastName")]
        public string LastName { get; set; }
        [BsonElement("academicDegree")]
        public string AcademicDegree { get; set; }
    }
}