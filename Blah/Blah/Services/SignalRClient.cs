using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blah.Services
{
    public class SignalRClient : INotifyPropertyChanged
    {
        public HubConnection _hub;
        public IHubProxy _smsHubProxy;
        public event EventHandler<ValueChangedEventArgs> ValueChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public HubConnection Hub { get { return _hub; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SignalRClient"/> class.
        /// </summary>



        public SignalRClient()
        {
            Debug.WriteLine("SignalR Initialized...");
            InitializeSignalR().ContinueWith(task =>
            {
                Debug.WriteLine("SignalR Started...");
            });
        }

        /// <summary>
        /// Initializes SignalR.
        /// </summary>
        public async Task InitializeSignalR()
        {


            _hub = new HubConnection("http://192.168.1.67");

            _smsHubProxy = _hub.CreateHubProxy("MySignalRHub");

            _hub.StateChanged += state =>
            {
                Console.WriteLine("Connection State Changed From {0} To {1}", state.OldState, state.NewState);
                if (state.NewState == ConnectionState.Disconnected)
                {
                    Console.WriteLine("Reconnecting in 500 ms");
                    Thread.Sleep(500);
                    _hub.Start(); // Will never reconnect. Workaround: Recreate connection CreateConnection().Start();
                }
            };

            _hub.Error += E => Console.WriteLine(E.Message);

                     

            _smsHubProxy.On<string, double>("NewUpdate",
                    (command, state) => ValueChanged?
                    .Invoke(this, new ValueChangedEventArgs(command, state)));

            _hub.TraceLevel = TraceLevels.All;
            _hub.TraceWriter = Console.Out;

            await _hub.Start();

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="state">The state.</param>
        public async Task SendMessage(string command, double state)
        {
            await _smsHubProxy.Invoke("NewUpdate", new object[] { command, state });
        }
    }

}
