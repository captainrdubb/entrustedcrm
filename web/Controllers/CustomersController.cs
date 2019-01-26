using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data;
using Entrusted.Web.Hubs;
using Microsoft.AspNetCore.Mvc;

namespace Entrusted.Web.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IRepository<Customer> customersRepository;

        public CustomersController(IRepository<Customer> customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public Task<List<Customer>> Get()
        {
            return this.customersRepository.ReadAll();
        }
    }
}