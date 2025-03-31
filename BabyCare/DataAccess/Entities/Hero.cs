using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BabyCare.DataAccess.Entities
{
    public class Hero
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string HeroId { get; set; }

        public string HeroTitle { get; set; }

        public string HeroDesc { get; set; }

        public string ImageUrl { get; set; }


    }
}
