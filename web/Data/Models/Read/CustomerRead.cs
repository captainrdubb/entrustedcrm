using System;
using System.Collections.Generic;
using Entrusted.Web.Data.Models.Write;
using MongoDB.Bson.Serialization.Attributes;

namespace Entrusted.Web.Data.Models.Read
{
    [BsonIgnoreExtraElements]
    public class CustomerRead
    {
        public string CustomerId { get; set; }
        public Guid Key { get; set; }
        public CustomerStatus Status { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<NoteRead> Notes { get; set; }
    }
}