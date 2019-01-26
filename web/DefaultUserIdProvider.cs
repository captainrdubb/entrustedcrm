using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;

namespace Entrusted.Web
{
    public class DefaultUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}