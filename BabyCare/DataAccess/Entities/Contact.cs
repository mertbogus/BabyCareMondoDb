using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BabyCare.DataAccess.Entities
{
    public class Contact
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ContactId { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string Mail { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkledinUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string SubsectionDesc { get; set; }
    }
}
