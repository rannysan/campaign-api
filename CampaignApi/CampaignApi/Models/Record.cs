using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CampaignApi.Models
{
    public class Record
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("User_id")]
        public string UserId { get; set; }

        [BsonElement("Campaign_id")]
        public string CampaignId { get; set; }

        [BsonElement("User_entries")]
        public int UserEntries { get; set; }

    }
}
