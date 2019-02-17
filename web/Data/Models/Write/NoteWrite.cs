using System;

namespace Entrusted.Web.Data.Models.Write
{
    public class NoteWrite
    {
        public Guid UserKey { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string Text { get; set; }
    }
}