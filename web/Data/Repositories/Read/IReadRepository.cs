using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data.Models.Write;
using MongoDB.Driver;

namespace Entrusted.Web.Data.Repositories.Read
{
    public interface IReadRepository<T>
    {
        Task<List<T>> ReadAll();
        Task<List<T>> Read(FilterDefinition<T> filter);
    }
}