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
        protected override Dictionary<string, ParamBuilder> allowedParams { get; set; } = new Dictionary<string, ParamBuilder>()
        {
            { "key", new ParamBuilder(nameof(CustomerRead.Key), new[] { ' ', ',', '|' }) },
            { "customerId", new ParamBuilder(nameof(CustomerRead.CustomerId), new[] { ' ', ',', '|' }) },
            { "first", new ParamBuilder(nameof(CustomerRead.GivenName), new[] { ' ', ',', '|' }) },
            { "last", new ParamBuilder(nameof(CustomerRead.FamilyName), new[] { ' ', ',', '|' }) },
            { "address", new ParamBuilder(nameof(CustomerRead.Address)) },
        };
    }
}