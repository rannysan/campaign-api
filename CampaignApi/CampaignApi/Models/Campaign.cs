using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CampaignApi.Models
{
    public class Campaign
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string CampaignName { get; set; }

        public string Description { get; set; }

        [BsonElement("Is_active")]
        public bool IsActive { get; set; }

        [BsonElement("Customer_id")]
        public string CustomerId { get; set; }
    }
}
