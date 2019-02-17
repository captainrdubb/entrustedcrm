using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data;
using Entrusted.Web.Data.Models;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Repositories.Read;
using Entrusted.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Entrusted.Web.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IReadRepository<CustomerRead> customersRepository;

        public CustomersController(IReadRepository<CustomerRead> customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public Task<List<CustomerRead>> Get()
        {
            return this.customersRepository.ReadAll();
        }
    }
}