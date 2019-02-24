using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Entrusted.Web.Data.Models.Read;

namespace Entrusted.Web.Data.Search
{
    public abstract class SearchStringParser<TEntity> : ISearchStringParser<TEntity>
    {
        protected abstract Dictionary<string, ParamBuilder> allowedParams { get; set; }

        private Regex pattern;

        public SearchStringParser()
        {
            var patternBuilder = new StringBuilder("(");
            foreach (var key in allowedParams.Keys)
            {
                patternBuilder.Append(key);
                patternBuilder.Append(":|");
            }
            patternBuilder.Remove(patternBuilder.Length - 1, 1);
            patternBuilder.Append(")");
            pattern = new Regex(patternBuilder.ToString(), RegexOptions.IgnoreCase);
        }

        public ILookup<string, SearchParam> Parse(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString)) return null;

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
                var resultParams = TryCreateParams(paramString[0], paramString[1]);
                searchParams.AddRange(resultParams);
            }

            return searchParams.ToLookup(param => param.Name);
        }

        private IEnumerable<SearchParam> TryCreateParams(string key, string value)
        {
            if (allowedParams.TryGetValue(key, out var paramBuilder))
            {
                return paramBuilder.Build(value);
            }

            return Enumerable.Empty<SearchParam>();
        }
    }
}