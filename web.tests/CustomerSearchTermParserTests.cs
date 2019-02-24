using System;
using System.Collections.Generic;
using System.Linq;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Search;
using Xunit;

namespace Entrusted.Web.Tests
{
    public class CustomerSearchTermParserTests
    {
        private Guid customerKeyOne = Guid.NewGuid();
        private Guid customerKeyTwo = Guid.NewGuid();
        private string customerId = "id";
        private string firstName = "Timmy";
        private string lastName = "O`Toule";
        private string address = "2123 Pow Dr. Tempe, AZ 89545-4895";

        private const string CustomerKeyPropertyName = nameof(CustomerRead.Key);
        private const string CustomerIdPropertyName = nameof(CustomerRead.CustomerId);
        private const string FirstNamePropertyName = nameof(CustomerRead.GivenName);
        private const string LastNamePropertyName = nameof(CustomerRead.FamilyName);
        private const string AddressPropertyName = nameof(CustomerRead.Address);

        [Fact]
        public void Parse_WhenStringHasValidPropertyKey_ReturnsSearchParam()
        {
            var parser = new CustomerSearchStringParser();

            var searchParams = parser.Parse($"key:{customerKeyOne}");

            Assert.Contains(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == $"{customerKeyOne}");
        }

        [Fact]
        public void Parse_WhenStringHasSameKeyMoreThanOnce_ReturnsEachParamWithCorrectValues()
        {
            var parser = new CustomerSearchStringParser();

            var searchParams = parser.Parse($"key:{customerKeyOne}key:{customerKeyTwo}");

            Assert.Contains(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == $"{customerKeyOne}");
            Assert.Contains(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == $"{customerKeyTwo}");
        }

        [Fact]
        public void Parse_WhenStringHasKeys_ReturnsEachParamWithCorrectValues()
        {
            var parser = new CustomerSearchStringParser();

            var searchParams = parser.Parse($"key:{customerKeyOne}customerId:{customerId}first:{firstName}last:{lastName}address:{address}");

            Assert.Contains(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == $"{customerKeyOne}");
            Assert.Contains(searchParams[CustomerIdPropertyName], searchParam => searchParam.Value == customerId);
            Assert.Contains(searchParams[FirstNamePropertyName], searchParam => searchParam.Value == firstName);
            Assert.Contains(searchParams[LastNamePropertyName], searchParam => searchParam.Value == lastName);
            Assert.Contains(searchParams[AddressPropertyName], searchParam => searchParam.Value == address);
        }

        [Fact]
        public void Parse_WhenStringHasOneKeyWithDelimitedValues_ReturnsParamForEachValue()
        {
            var parser = new CustomerSearchStringParser();

            var searchParams = parser.Parse($"key:{customerKeyOne},{customerKeyTwo} {customerId}|{firstName}");

            Assert.Contains(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == $"{customerKeyOne}");
            Assert.Contains(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == $"{customerKeyTwo}");
            Assert.Contains(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == customerId);
            Assert.Contains(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == firstName);
        }

        [Fact]
        public void Parse_WhenStringHasTrailingComma_DoesNotCreateEmptyParam()
        {
            var parser = new CustomerSearchStringParser();

            var searchParams = parser.Parse($"key:{customerKeyOne},");

            Assert.Contains(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == $"{customerKeyOne}");
            Assert.DoesNotContain(searchParams[CustomerKeyPropertyName], searchParam => searchParam.Value == string.Empty);
        }

        [Fact]
        public void Parse_WhenStringHasAddress_DoesNotSplitAddressIntoSeperateParams()
        {
            var parser = new CustomerSearchStringParser();

            var searchParams = parser.Parse($"address:an address with spaces, commas, and stuff");

            Assert.Single(searchParams[nameof(CustomerRead.Address)]);
        }


        [Fact]
        public void Parse_WhenStringHasInvalidPropertyKey_ExcludesPropertyKey()
        {
            var parser = new CustomerSearchStringParser();

            var searchParam = parser.Parse($"invalid:{customerKeyOne}");

            Assert.Empty(searchParam);
        }

        private CustomerRead GetCustomer()
        {
            return new CustomerRead() { Key = customerKeyOne, CustomerId = "1" };
        }
    }
}
