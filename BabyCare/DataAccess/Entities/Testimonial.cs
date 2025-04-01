using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCare.DataAccess.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string Description { get; set; }
        public string CommenterFullName { get; set; }
        public string CommenterImage { get; set; }
        public int Rating { get; set; }
    }
}
