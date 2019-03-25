using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Entrusted.Web.Data.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CustomerStatus
    {
        Prospective,
        Current,
        [EnumMember(Value = "Non-Active")] NonActive
    }
}