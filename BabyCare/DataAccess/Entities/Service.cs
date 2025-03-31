using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCare.DataAccess.Entities
{
    public class Service
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceId { get; set; }
        public string ServiceDesc { get; set; }
        public string ServiceTitle { get; set; }
        public string Icon { get; set; }

    }
}
