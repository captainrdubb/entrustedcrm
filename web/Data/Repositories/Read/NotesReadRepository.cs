using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data.Models.Read;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Entrusted.Web.Data.Repositories.Read
{
    public class NotesReadRepository : IReadRepository<NoteRead>
    {
        private readonly IMongoCollection<NoteRead> collection;

        public NotesReadRepository(IMongoDatabase database)
        {
            this.collection = database.GetCollection<NoteRead>("CustomerNote");
        }

        public Task<List<NoteRead>> Read(FilterDefinition<NoteRead> filter)
        {
            return collection.Find(filter).ToListAsync();
        }

        public Task<List<NoteRead>> ReadAll()
        {
            var customers = collection.Find(Builders<NoteRead>.Filter.Empty).ToListAsync();
            return customers;
        }
    }
}