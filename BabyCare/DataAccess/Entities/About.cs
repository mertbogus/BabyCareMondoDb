using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCare.DataAccess.Entities
{
    public class About
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutId { get; set; }
        public string AboutTitle { get; set; }
        public string AboutDesc { get; set; }
        public string AboutYoutubeUrl { get; set; }

    }
}
