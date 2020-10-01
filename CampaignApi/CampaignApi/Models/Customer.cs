using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CampaignApi.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string CustomerName { get; set; }

        public string Cnpj { get; set; }
    }
}
