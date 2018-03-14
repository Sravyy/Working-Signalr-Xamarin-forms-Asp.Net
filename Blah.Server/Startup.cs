using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;

namespace Blah.Server
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr", map =>
            {

                map.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration
                {

                };

                map.RunSignalR(hubConfiguration);
            });
        }
    }   
}