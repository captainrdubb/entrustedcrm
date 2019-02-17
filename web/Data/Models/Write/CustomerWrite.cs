using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Entrusted.Web.Data.Models.Write
{
    [BsonIgnoreExtraElements]
    public class Customer
    {
        public Guid Key { get; set; }
        public CustomerStatus Status { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset UpdatedOn { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<NoteWrite> Notes { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CustomerStatus
    {
        Prospective,
        Current,
        [EnumMember(Value = "non-active")] NonActive
    }
}
