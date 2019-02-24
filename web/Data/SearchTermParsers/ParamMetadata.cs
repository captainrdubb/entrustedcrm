using System;
using System.Collections.Generic;
using System.Linq;

namespace Entrusted.Web.Data.Search
{
    public class ParamBuilder
    {
        private string propertyName;
        private char[] valueDelimiters;
        public ParamBuilder(string propertyName) : this(propertyName, null)
        {
        }

        public ParamBuilder(string propertyName, char[] valueDelimiters)
        {
            this.propertyName = propertyName;
            this.valueDelimiters = valueDelimiters;
        }

        public IEnumerable<SearchParam> Build(string value)
        {
            if (valueDelimiters != null)
            {
                IEnumerable<string> values = value.Split(valueDelimiters);
                return values.Where(v => string.IsNullOrEmpty(v) == false).Select(v => new SearchParam(propertyName, v));
            }
            return Enumerable.Repeat(new SearchParam(propertyName, value), 1);
        }
    }
}