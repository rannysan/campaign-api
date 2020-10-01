using CampaignApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CampaignApi.Services
{
    public class RecordService
    {
        private readonly IMongoCollection<Record> _record;

        public RecordService(ICampaignDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _record = database.GetCollection<Record>("Records");
        }

        public Record Register(Record record)
        {
            _record.InsertOne(record);
            return record;
        }

        public List<Record> GetTop10(string campaign_id)
        {
            var list = _record.Find(record => record.CampaignId == campaign_id).Limit(10).SortBy(x => x.UserEntries).ThenByDescending(x => x.UserEntries).ToList();

            return list;
        }

        public List<Record> GetAll(string campaign_id)
        {
            var list = _record.Find(record => record.CampaignId == campaign_id).SortBy(x => x.UserEntries).ThenByDescending(x => x.UserEntries).ToList();

            return list;
        }

        public int UserRegisterCount(string user_id)
        {
            var count = _record.Find(record => record.UserId == user_id).ToList().Count();

            return count;
        }

        public void AddEntry(string id)
        {
            var recordIn = _record.Find<Record>(record => record.Id == id).FirstOrDefault();

            recordIn.UserEntries = recordIn.UserEntries + 1;

            _record.ReplaceOne(record => record.Id == id, recordIn);
        }

        public int GetPosition (string user_id, string campaign_id)
        {
            var list = _record.Find(record => record.CampaignId == campaign_id).Limit(10).SortBy(x => x.UserEntries).ThenByDescending(x => x.UserEntries).ToList();

            var userRecord = list.Find(f => f.UserId == user_id);

            var position = Array.IndexOf(list.ToArray(), userRecord);

            return position + 1;
        }
    }
}
