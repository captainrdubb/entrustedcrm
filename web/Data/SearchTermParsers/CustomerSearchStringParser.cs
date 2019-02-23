using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Entrusted.Web.Data.Models.Read;

namespace Entrusted.Web.Data.Search
{
    public class CustomerSearchStringParser : SearchStringParser<CustomerRead>
    {
        protected override Dictionary<string, string> allowedKeys { get; set; } = new Dictionary<string, string>()
        {
            { "key", nameof(CustomerRead.Key) },
            { "customerId", nameof(CustomerRead.CustomerId) },
            { "first", nameof(CustomerRead.GivenName) },
            { "last", nameof(CustomerRead.FamilyName) },
            { "address", nameof(CustomerRead.Address) },
        };
    }
}