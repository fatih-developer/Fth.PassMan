using Core.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Concrete;

public class Category:MongoModel
{
    public Category()
    {
        
    }

    public Category(string categoryName)
    {
        this.CategoryName = categoryName;
    }

    [BsonElement("categoryname")]
    public string CategoryName { get; set; }

}