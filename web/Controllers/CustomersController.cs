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
            var searchParams = searchStringParser.Parse(q);
            var filterDefinition = SearchFilterBuilder.Build<CustomerRead>(searchParams);
            return this.customerReadRepo.Read(filterDefinition);
        }

        [HttpPost]
        public Task Post([FromBody] CustomerWrite customer)
        {
            customer.Key = Guid.NewGuid();
            return this.customerWriteRepo.Write(customer);
        }
    }
}