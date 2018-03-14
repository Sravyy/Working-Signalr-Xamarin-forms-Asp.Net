//using Microsoft.AspNet.SignalR;
//using Microsoft.AspNet.SignalR.Hubs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;

//namespace Blah.Server.Hubs
//{
//    [HubName("MySignalRHub")]
//    public class MySignalRHub : Hub
//    {
//        public void NewUpdate(string command, double state)
//        {
//            Clients.All.NewUpdate(command, state);
//        }

//        //public override Task OnConnected()
//        //{
//        //    return base.OnConnected();
//        //}
//    }
//}