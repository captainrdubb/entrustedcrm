using System;

namespace Entrusted.Web.Data.Models.Write
{
    public class EntrustedUserWrite
    {
        public Guid Key { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string EmployeeId { get; set; }
    }
}