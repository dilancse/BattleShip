using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class WebSocketGameServer
{
	private WebSocketServer webSocketServer = null;
	private WebSocketServiceHost serviceHost = null;
	private GameService currentGameService = null;
	private string currentService = null;

	public WebSocketGameServer (string url, string service)
	{
		if (!string.IsNullOrEmpty (url) && !string.IsNullOrEmpty (service)) {
			webSocketServer = new WebSocketServer (url);
			webSocketServer.AddWebSocketService<GameService> (service);
			currentService = service;
		}
		
	}

	public void StartServer ()
	{
		if (webSocketServer != null)
			webSocketServer.Start ();
	}

	public void StopServer ()
	{
		if (webSocketServer != null)
			webSocketServer.Stop ();
	}

	public WebSocketServiceHost GetServiceHost (string service)
	{

		if (serviceHost != null)
			return serviceHost;
		else {
			if (webSocketServer.WebSocketServices.TryGetServiceHost (service, out serviceHost))
				return serviceHost;
			else
				return null;
		}
	}

	//			public GameService GetGameService(string service){
	//				if (currentGameService != null)
	//					return currentGameService;
	//					else{
	//					WebSocketServiceHost host = GetServiceHost (service);
	//					if (host != null && host.BehaviorType == typeof(GameService))
	//
	//					}
	//			}

	public void SendMessage (string message)
	{
		
	}
}
