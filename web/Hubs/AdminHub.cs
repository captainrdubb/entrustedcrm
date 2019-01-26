using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Entrusted.Web.Hubs
{
    public class AdminHub : Hub
    {
        private readonly IEventBus eventbus;

        public AdminHub(IEventBus eventbus)
        {
            this.eventbus = eventbus;
        }        
    }

    public interface IEventBus
    {
    }

    public class EventBus : IEventBus
    {

    }
}
