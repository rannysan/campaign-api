using CampaignApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace CampaignApi.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(ICampaignDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customer = database.GetCollection<Customer>("Customers");
        }

        public List<Customer> GetList()
        {
            var list = _customer.Find(customer => true).ToList();

            return list;
        }

        public Customer GetById(string id)
        {
            var customer = _customer.Find<Customer>(customer => customer.Id == id).FirstOrDefault();

            return customer;
        }

        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);
            return customer;
        }

        public void Update(string id, Customer customerIn)
        {
            _customer.ReplaceOne(customer => customer.Id == id, customerIn);
        }

        public void Remove(Customer customerIn)
        {
            _customer.DeleteOne(customer => customer.Id == customerIn.Id);
        }

        public void Remove(string id)
        {
            _customer.DeleteOne(customer => customer.Id == id);
        }

    }
}
