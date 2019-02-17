using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entrusted.Web.Data;
using Entrusted.Web.Data.Models;
using Entrusted.Web.Data.Models.Read;
using Entrusted.Web.Data.Repositories.Read;
using Entrusted.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Entrusted.Web.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly IReadRepository<NoteRead> notesRepository;

        public NotesController(IReadRepository<NoteRead> notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public Task<List<NoteRead>> Get(Guid customerKey)
        {
            if (Guid.Empty != customerKey)
            {
                var filter = Builders<NoteRead>.Filter.Eq(note => note.CustomerKey, customerKey);
                var results = this.notesRepository.Read(filter);
                return results;
            }
            return this.notesRepository.ReadAll();
        }
    }
}