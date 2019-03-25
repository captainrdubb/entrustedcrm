using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data;
using Entrusted.Web.Data.Models;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Models.Write;
using Entrusted.Web.Data.Repositories.Read;
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
        private readonly IReadRepository<CustomerRead> customersRepository;

        public CustomersController(IReadRepository<CustomerRead> customersRepository, ISearchStringParser<CustomerRead> parser)
        {
            this.searchStringParser = parser;
            this.customersRepository = customersRepository;
        }

        public Task<List<CustomerRead>> Get(string q)
        {
            var searchParams = searchStringParser.Parse(q);
            var filterDefinition = EntrustedFilterBuilder.Build<CustomerRead>(searchParams);
            return this.customersRepository.Read(filterDefinition);
        }

        public Task Post(CustomerWrite customer)
        {
            this.customersRepository.Write(customer);
        }
    }
}