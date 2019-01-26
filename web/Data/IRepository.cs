using System.Collections.Generic;
using System.Threading.Tasks;

namespace Entrusted.Web.Data
{
    public interface IRepository<T>
    {
        Task<List<T>> ReadAll();
    }
}