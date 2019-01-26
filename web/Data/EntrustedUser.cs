using System;

namespace Entrusted.Web.Data
{
    public class EntrustedUser
    {
        public Guid Key { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string EmployeeId { get; set; }
    }
}