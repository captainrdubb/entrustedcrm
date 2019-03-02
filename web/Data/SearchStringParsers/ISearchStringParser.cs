using System;
using System.Linq;

namespace Entrusted.Web.Data.Search
{
    public interface ISearchStringParser<TEntity>
    {
        ILookup<string, SearchParam> Parse(string searchTerm);
    }
}