using System.Collections.Generic;
using System.Linq;
using Entrusted.Web.Data;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Search;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using Xunit;

namespace Entrusted.Web.Tests
{
    public class EntrustedFilterBuilderTests
    {
        [Fact]
        public void Build_WhenParamsEmpty_ReturnsEmptyFilter()
        {
            ILookup<string, SearchParam> searchParams = new List<SearchParam>().ToLookup(sp => sp.Name);

            FilterDefinition<object> filter = SearchFilterBuilder.Build<object>(searchParams);
            var str = JsonConvert.SerializeObject(filter);

            Assert.Equal("{}", str);
        }

        [Fact]
        public void Build_WhenParamsNull_ReturnsEmptyFilter()
        {
            FilterDefinition<object> filter = SearchFilterBuilder.Build<object>(null);
            string str = JsonConvert.SerializeObject(filter);

            Assert.Equal("{}", str);
        }
    }
}