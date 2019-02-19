using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Entrusted.Web.Data.Models.Read;

namespace Entrusted.Web.Data.SearchTermParsers
{
    public class CustomerSearchTermParser : ISearchTermParser<CustomerRead>
    {
        private Dictionary<string, string> allowedKeys = new Dictionary<string, string>(){
            { "key", nameof(CustomerRead.Key) },
            { "customerId", nameof(CustomerRead.CustomerId) },
            { "first", nameof(CustomerRead.GivenName) },
            { "last", nameof(CustomerRead.FamilyName) },
            { "address", nameof(CustomerRead.Address) },
        };
        
        public Func<CustomerRead, bool> Parse(string searchTerm)
        {
            var terms = searchTerm.Split(":");
            return (customer) => true;
        }
    }
}