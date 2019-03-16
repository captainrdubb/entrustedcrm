using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Entrusted.Web.Data.Models.Read
{
    [BsonIgnoreExtraElements]
    public class NoteRead
    {
        public Guid CustomerKey { get; internal set; }
        public EntrustedUserRead CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public EntrustedUserRead UpdatedBy { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string Text { get; set; }
    }
}