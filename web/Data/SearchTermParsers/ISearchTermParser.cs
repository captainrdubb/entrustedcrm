using System;

namespace Entrusted.Web
{
    public interface ISearchTermParser<TEntity>
    {
        Func<TEntity, bool> Parse(string searchTerm);
    }
}