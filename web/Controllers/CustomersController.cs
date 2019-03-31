using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data;
using Entrusted.Web.Data.Models;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Models.Write;
using Entrusted.Web.Data.Repositories.Read;
using Entrusted.Web.Data.Repositories.Write;
using Entrusted.Web.Data.Search;
using Entrusted.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Entrusted.Web.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ISearchStringParser<CustomerRead> searchStringParser;
        private readonly IWriteRepository<CustomerWrite> customerWriteRepo;
        private readonly IReadRepository<CustomerRead> customerReadRepo;

        public CustomersController(IWriteRepository<CustomerWrite> customerWriteRepo, IReadRepository<CustomerRead> customerReadRepo, ISearchStringParser<CustomerRead> parser)
        {
            this.searchStringParser = parser;
            this.customerWriteRepo = customerWriteRepo;
            this.customerReadRepo = customerReadRepo;
        }

        public Task<List<CustomerRead>> Get(string q)
        {
            if (string.IsNullOrEmpty(q))
            {
                var deletedFilter = Builders<CustomerRead>.Filter.Eq(c => c.IsDeleted, false);
                var existsFilter = Builders<CustomerRead>.Filter.Exists(c => c.IsDeleted, false);
                var filter = Builders<CustomerRead>.Filter.Or(deletedFilter, existsFilter);
                return this.customerReadRepo.Read(filter);
            }

            var searchParams = searchStringParser.Parse(q);
            var filterDefinition = SearchFilterBuilder.Build<CustomerRead>(searchParams);
            return this.customerReadRepo.Read(filterDefinition);
        }

        [HttpDelete]
        [Route("{key}")]
        public Task Delete(Guid key)
        {
            return this.customerWriteRepo.Delete(key);
        }

        [HttpPost]
        public Task Post([FromBody] CustomerWrite customer)
        {
            customer.Key = Guid.NewGuid();
            customer.CreatedOn = DateTimeOffset.UtcNow;
            return this.customerWriteRepo.Write(customer);
        }
    }
}