using System;

namespace Entrusted.Web.Data
{
    public class Note
    {
        public Guid UserKey { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Text { get; set; }
    }
}