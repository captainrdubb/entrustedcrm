using System;

namespace Entrusted.Web
{
    public interface ISearchTermParser<TEntity>
    {
        Func<TEntity, object> Parse(string searchTerm);
    }
}