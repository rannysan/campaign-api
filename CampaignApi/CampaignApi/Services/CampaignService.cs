using CampaignApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CampaignApi.Services
{
    public class CampaignService
    {
        private readonly IMongoCollection<Campaign> _campaign;

        public CampaignService(ICampaignDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _campaign = database.GetCollection<Campaign>("Campaigns");
        }

        public List<Campaign> GetList()
        {
            var list = _campaign.Find(campaign => true).ToList();

            return list;
        }

        public Campaign GetById(string id)
        {
            var campaign = _campaign.Find<Campaign>(campaign => campaign.Id == id).FirstOrDefault();

            return campaign;
        }

        public List<Campaign> GetByCustomerId(string customer_id)
        {
            var list = _campaign.Find<Campaign>(campaign => campaign.CustomerId == customer_id).ToList();

            return list;
        }

        public Campaign Create(Campaign campaign)
        {
            _campaign.InsertOne(campaign);
            return campaign;
        }

        public void Update(string id, Campaign campaignIn)
        {
            _campaign.ReplaceOne(campaign => campaign.Id == id, campaignIn);
        }

        public void Remove(Campaign campaignIn)
        {
            _campaign.DeleteOne(campaign => campaign.Id == campaignIn.Id);
        }

        public void Remove(string id)
        {
            _campaign.DeleteOne(campaign => campaign.Id == id);
        }
    }
}