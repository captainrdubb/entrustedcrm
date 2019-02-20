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

        [Fact]
        public void Parse_WhenStringEmpty_ThrowsArgumentNullException()
        {
            var parser = new CustomerSearchTermParser();

            Assert.Throws<ArgumentNullException>(() => parser.Parse(string.Empty));
        }

        [Fact]
        public void Parse_WhenStringHasValidPropertyKey_ReturnsLambdaYieldingProperty()
        {
            var parser = new CustomerSearchTermParser();
            var customer = GetCustomer();

            var predicate = parser.Parse($"key:{customerKeyOne}");

            Assert.Equal(customer.Key, predicate(customer));
        }

        [Fact]
        public void Parse_WhenStringDoesNotHasValidPropertyKey_ThrowsArgumentExeption()
        {
            var parser = new CustomerSearchTermParser();

            Assert.Throws<ArgumentException>(() => parser.Parse($"invalid:{customerKeyOne}"));
        }

        private CustomerRead GetCustomer()
        {
            return new CustomerRead() { Key = customerKeyOne };
        }
    }
}
