using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CampaignApi.Models
{
    public class Prize
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string PrizeName { get; set; }

        public double Weight { get; set; }

        public int Rarity { get; set; }
    }
}
