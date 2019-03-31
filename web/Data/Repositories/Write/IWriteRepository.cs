using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data.Models.Write;
using MongoDB.Driver;

namespace Entrusted.Web.Data.Repositories.Write
{
    public interface IWriteRepository<T>
    {
        Task Write(T customer);
        Task Delete(Guid key);
    }
}