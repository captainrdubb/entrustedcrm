using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data;
using Entrusted.Web.Data.Models;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Models.Write;
using Entrusted.Web.Data.Repositories.Read;
using Entrusted.Web.Data.Repositories.Write;
using Entrusted.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Entrusted.Web.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly IReadRepository<NoteRead> notesReadRepository;
        private readonly IWriteRepository<NoteWrite> notesWriteRepository;

        public NotesController(IReadRepository<NoteRead> notesReadRepository, IWriteRepository<NoteWrite> notesWriteRepository)
        {
            this.notesReadRepository = notesReadRepository;
            this.notesWriteRepository = notesWriteRepository;
        }

        public Task<List<NoteRead>> Get(Guid customerKey)
        {
            if (Guid.Empty != customerKey)
            {
                var filter = Builders<NoteRead>.Filter.Eq(note => note.CustomerKey, customerKey);
                var results = this.notesReadRepository.Read(filter);
                return results;
            }
            return this.notesReadRepository.ReadAll();
        }

        [HttpDelete]
        [Route("{key}")]
        public Task Delete(Guid key)
        {
            return this.notesWriteRepository.Delete(key);
        }
    }
}