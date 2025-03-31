using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCare.DataAccess.Entities
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EventId { get; set; }
        public string EventTitle { get; set; }
        public string EventDesc { get; set; }
        public DateTime EventDate { get; set; }
        public string EventCity { get; set; }
        public string EventTime { get; set; }
        public string ImageUrl { get; set; }



    }
}
