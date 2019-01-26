using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using StackExchange.Redis;

namespace Entrusted.Web.Hubs
{
    public class AdminHub : Hub
    {
        public AdminHub()
        {
        }

        public override Task OnConnectedAsync()
        {
            return Clients.Caller.SendAsync("Fetching", new { area = "Customers" });
        }
    }

    public class Customer
    {
    }
}
