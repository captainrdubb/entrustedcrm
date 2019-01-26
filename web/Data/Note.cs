using System;

namespace Entrusted.Web.Data
{
    public class Note
    {
        public EntrustedUser EntrustedUser { get; set; }
        public string Text { get; set; }
    }
}