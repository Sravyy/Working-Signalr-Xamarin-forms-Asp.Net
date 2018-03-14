using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Blah.Server
{
    [HubName("MySignalRHub")]
    public class MySignalRHub1 : Hub
    {
        public void NewUpdate(string command, double state)
        {
            Clients.All.NewUpdate(command, state);
        }

        //public override Task OnConnected()
        //{
        //    return base.OnConnected();
        //}
    }
}