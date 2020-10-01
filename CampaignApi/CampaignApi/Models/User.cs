using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CampaignApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string UserName { get; set; }

        [BsonElement("Last_name")]
        public string LastName { get; set; }

        [BsonElement("Cell_number")]
        public string CellNumber { get; set; }

        public string Email { get; set; }
    }
}
