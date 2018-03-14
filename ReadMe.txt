Replace the SignalRServer new connection with the Emulator IP
Using Local IIS instead of IIS Express(Create a site in IIS and set path to the folder where the server resides)
set path in Server project to localhost("http://localhost" rewrites default configuration)
check if the signalr server running(/signalr/hubs .. should pull the the signalr info. if the server starts)
check if the Emulator is working with signalr(check the ip with /singalr/hubs)

