using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Project.Server
{
    [HubName("MySignalRHub")]
    public class MyHub1 : Hub
    {
        public void NewUpdate(string command, double state)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MyHub1>();
            context.Clients.All.NewUpdate(command, state);
        }

        //public void CauseError(int a)
        //{
        //    if(a < 0)
        //    {
        //        throw new HubException("'a' must be greater than 0", a);
        //    }
        //    else if(a > 0)
        //    {
        //        throw new InvalidOperationException("This will not be sent to the client");
        //    }
        //}


        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        //    namespace BasicChat
        //{
        //    [Authorize]
        //    public class ChatHub : Hub
        //    {
        //        private readonly static ConnectionMapping<string> _connections =
        //            new ConnectionMapping<string>();

        //        public void SendChatMessage(string who, string message)
        //        {
        //            string name = Context.User.Identity.Name;

        //            foreach (var connectionId in _connections.GetConnections(who))
        //            {
        //                Clients.Client(connectionId).addChatMessage(name + ": " + message);
        //            }
        //        }

        //        public override Task OnConnected()
        //        {
        //            string name = Context.User.Identity.Name;

        //            _connections.Add(name, Context.ConnectionId);

        //            return base.OnConnected();
        //        }

        //        public override Task OnDisconnected(bool stopCalled)
        //        {
        //            string name = Context.User.Identity.Name;

        //            _connections.Remove(name, Context.ConnectionId);

        //            return base.OnDisconnected(stopCalled);
        //        }

        //        public override Task OnReconnected()
        //        {
        //            string name = Context.User.Identity.Name;

        //            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
        //            {
        //                _connections.Add(name, Context.ConnectionId);
        //            }

        //            return base.OnReconnected();
        //        }
        //    }
        //}
    }
}