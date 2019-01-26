using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Entrusted.Web.Data
{
    public class CustomersRepository : IRepository<Customer>
    {
        private readonly IMongoCollection<Customer> collection;

        public CustomersRepository(IMongoDatabase database)
        {
            this.collection = database.GetCollection<Customer>("Customer");
        }

        public Task<List<Customer>> ReadAll()
        {
            return collection.Find(Builders<Customer>.Filter.Empty).ToListAsync();
        }
    }
}