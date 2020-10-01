using CampaignApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CampaignApi.Services
{
    public class PrizeService
    {
        private readonly IMongoCollection<Prize> _prize;

        public PrizeService(ICampaignDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _prize = database.GetCollection<Prize>("Prizes");
        }

        public List<Prize> GetList()
        {
            var list = _prize.Find(prize => true).ToList();

            return list;
        }

        public List<Prize> GetListByPosition(int position)
        {
            if (position >= 1 && position <= 3)
                return _prize.Find(prize => prize.Rarity.Equals(3) || prize.Rarity.Equals(4)).ToList();
            else if (position > 3 && position < 7)
                return _prize.Find(prize => prize.Rarity.Equals(3) || prize.Rarity.Equals(4) || prize.Rarity.Equals(2)).ToList();

            return _prize.Find(prize => prize.Rarity.Equals(3) || prize.Rarity.Equals(1) || prize.Rarity.Equals(2)).ToList();
        }

        public Prize GetById(string id)
        {
            var prize = _prize.Find<Prize>(prize => prize.Id == id).FirstOrDefault();

            return prize;
        }

        public Prize Create(Prize prize)
        {
            _prize.InsertOne(prize);
            return prize;
        }

        public void Update(string id, Prize prizeIn)
        {
            _prize.ReplaceOne(prize => prize.Id == id, prizeIn);
        }

        public void Remove(string id)
        {
            _prize.DeleteOne(prize => prize.Id == id);
        }
    }
}