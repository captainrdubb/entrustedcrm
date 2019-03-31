using System;

namespace Entrusted.Web.Data.Models.Write
{
    public class NoteWrite
    {
        public Guid Key { get; set; }
        public Guid CustomerKey { get; set; }
        public EntrustedUserWrite CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public EntrustedUserWrite UpdatedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string Text { get; set; }
    }
}