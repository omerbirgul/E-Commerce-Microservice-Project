using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entities
{
    public class CategorySlide
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategorySlideId { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryImageUrl { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
