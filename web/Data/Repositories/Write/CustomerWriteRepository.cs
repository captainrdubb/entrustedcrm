using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Models.Write;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Entrusted.Web.Data.Repositories.Write
{
    public class CustomerWriteRepository : IWriteRepository<CustomerWrite>
    {
        private readonly IMongoCollection<CustomerWrite> collection;

        public CustomerWriteRepository(IMongoDatabase database)
        {
            this.collection = database.GetCollection<CustomerWrite>("Customer");
        }

        public Task Write(CustomerWrite customer)
        {
            var filter = Builders<CustomerWrite>.Filter.Eq(c => c.Key, customer.Key);
            var updateOptions = new UpdateOptions() { IsUpsert = true };
            return this.collection.ReplaceOneAsync(filter, customer, updateOptions);
        }
    }
}