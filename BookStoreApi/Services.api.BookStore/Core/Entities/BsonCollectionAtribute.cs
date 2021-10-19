using System;

namespace Services.api.BookStore.Core.Entities
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAtribute : Attribute
    {
        public string CollectionName { get; }

        public BsonCollectionAtribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}