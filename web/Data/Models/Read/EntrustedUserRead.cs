using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Entrusted.Web.Data.Models.Read
{
    [BsonIgnoreExtraElements]
    public class EntrustedUserRead
    {
        public Guid Key { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
    }
}