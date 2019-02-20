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

        public Func<CustomerRead, object> Parse(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) throw new ArgumentNullException(nameof(searchTerm));

            var terms = searchTerm.Split(':');

            try
            {
                var propertyName = allowedKeys[terms[0]];
                var propertyInfo = typeof(CustomerRead).GetProperty(propertyName);
                return (customer) => propertyInfo.GetValue(customer);
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException($"Invalid property name found in search terms, {terms[0]}");
            }
        }
    }
}