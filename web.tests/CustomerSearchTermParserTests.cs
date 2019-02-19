using System;
using System.Collections.Generic;
using System.Linq;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.SearchTermParsers;
using Xunit;

namespace web.tests
{
    public class CustomerSearchTermParserTests
    {
        public Guid customerKeyOne = Guid.NewGuid();
        public Guid customerKeyTwo = Guid.NewGuid();
        public Guid customerKeyThree = Guid.NewGuid();

        [Fact]
        public void Parse_WhenStringEmpty_ReturnsNonFilteringLambda()
        {
            var parser = new CustomerSearchTermParser();
            var customers = GetCustomers();

            var predicate = parser.Parse(string.Empty);

            Assert.Equal(3, customers.Where(predicate).Count());
        }

        [Fact]
        public void Parse_WhenStringNotEmpty_ReturnsFilteringLambda()
        {
            var parser = new CustomerSearchTermParser();
            var customers = GetCustomers();

            var predicate = parser.Parse($"key:{customerKeyOne}");

            Assert.Equal(1, customers.Where(predicate).Count());
        }

        private List<CustomerRead> GetCustomers()
        {
            return new List<CustomerRead>()
            {
                new CustomerRead(){ Key = customerKeyOne },
                new CustomerRead(){ Key = customerKeyTwo },
                new CustomerRead(){ Key = customerKeyThree }
            };
        }
    }
}
