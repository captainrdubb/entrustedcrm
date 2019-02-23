using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Entrusted.Web.Data.Models.Read;

namespace Entrusted.Web.Data.Search
{
    public class CustomerSearchStringParser : ISearchStringParser<CustomerRead>
    {
        private static Regex pattern = new Regex("(key:|customerId:|first:|last:|address:)", RegexOptions.IgnoreCase);

        private Dictionary<string, string> allowedKeys = new Dictionary<string, string>(){
            { "key", nameof(CustomerRead.Key) },
            { "customerId", nameof(CustomerRead.CustomerId) },
            { "first", nameof(CustomerRead.GivenName) },
            { "last", nameof(CustomerRead.FamilyName) },
            { "address", nameof(CustomerRead.Address) },
        };

        public ILookup<string, SearchParam> Parse(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString)) throw new ArgumentNullException(nameof(searchString));

            var searchParams = new List<SearchParam>();
            var matchIndexes = pattern.Matches(searchString).Select(m => m.Index).ToArray();
            var matchesCount = matchIndexes.Length;
            var start = 0;
            var end = 0;
            for (int i = 0; i < matchesCount; ++i)
            {
                start = matchIndexes[i];
                if (i + 1 < matchesCount) end = matchIndexes[i + 1];
                else end = searchString.Length;

                end -= start;

                var paramString = searchString.Substring(start, end).Split(":");
                var searchParam = TryCreateParam(paramString[0], paramString[1]);
                if (searchParam != null) searchParams.Add(searchParam);
            }

            return searchParams.ToLookup(param => param.Name);
        }

        private SearchParam TryCreateParam(string key, string value)
        {
            if (allowedKeys.TryGetValue(key, out var propertyName)) return new SearchParam(propertyName, value);
            else return null;
        }
    }
}