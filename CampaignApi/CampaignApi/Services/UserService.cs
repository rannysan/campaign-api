using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using CampaignApi.Models;

namespace UserApi.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _user;

        public UserService(ICampaignDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _user = database.GetCollection<User>("Users");
        }

        public List<User> GetList()
        {
            var list = _user.Find(user => true).ToList();

            return list;
        }
        public User GetById(string id)
        {
            var user = _user.Find<User>(user => user.Id == id).FirstOrDefault();

            return user;
        }

        public User Create(User user)
        {
            _user.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            _user.ReplaceOne(user => user.Id == id, userIn);
        }

        public void Remove(User userIn)
        {
            _user.DeleteOne(user => user.Id == userIn.Id);
        }

        public void Remove(string id)
        {
            _user.DeleteOne(user => user.Id == id);
        }

        public int UserRegisterCount(string id)
        {
            return 0;
        }
    }
}
