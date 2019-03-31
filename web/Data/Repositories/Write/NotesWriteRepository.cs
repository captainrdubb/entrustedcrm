using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Models.Write;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Entrusted.Web.Data.Repositories.Write
{
    public class NotesWriteRepository : IWriteRepository<NoteWrite>
    {
        private readonly IMongoCollection<NoteWrite> collection;

        public NotesWriteRepository(IMongoDatabase database)
        {
            this.collection = database.GetCollection<NoteWrite>("CustomerNote");
        }

        public Task Delete(Guid key)
        {
            var filter = Builders<NoteWrite>.Filter.Eq(n => n.Key, key);
            return this.collection.DeleteOneAsync(filter);
        }

        public Task Write(NoteWrite customer)
        {
            throw new NotImplementedException();
        }
    }
}