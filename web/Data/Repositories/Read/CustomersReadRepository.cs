using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data.Models.Read;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Entrusted.Web.Data.Repositories.Read
{
    public class CustomersReadRepository : IReadRepository<CustomerRead>
    {
        private readonly IMongoCollection<CustomerRead> collection;

        public CustomersReadRepository(IMongoDatabase database)
        {
            this.collection = database.GetCollection<CustomerRead>("Customer");
        }

        public Task<List<CustomerRead>> Read(FilterDefinition<CustomerRead> filter)
        {
            return collection.Find(filter).ToListAsync();
        }

        public Task<List<CustomerRead>> ReadAll()
        {
            var filter = Builders<CustomerRead>.Filter.Eq(c => c.IsDeleted, false);
            var customers = collection.Find(filter).ToListAsync();
            return customers;
        }
    }
}