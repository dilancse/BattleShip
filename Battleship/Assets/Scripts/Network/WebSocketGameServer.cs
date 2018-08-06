using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Linq;

public class WebSocketGameServer
{
	private WebSocketServer webSocketServer = null;
	private WebSocketServiceHost serviceHost = null;
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
		else if (!string.IsNullOrEmpty (service)) {
			if (webSocketServer.WebSocketServices.TryGetServiceHost (service, out serviceHost))
				return serviceHost;
			else
				return null;
		} else
			return null;
	}


	public List<GameService> GetAllGameServices (string service)
	{
		WebSocketServiceHost host = GetServiceHost (service);

		if (host != null && host.BehaviorType == typeof(GameService)) {
			IEnumerable<GameService> allServices = host.Sessions.Sessions as IEnumerable<GameService>;
			return allServices.ToList<GameService> ();
		} else
			return null;					
	}

	public GameService GetGameService (string serviceId)
	{
		WebSocketServiceHost host = GetServiceHost (currentService);

		if (host != null && !string.IsNullOrEmpty (serviceId) && host.BehaviorType == typeof(GameService)) {
			IWebSocketSession session;
			if (host.Sessions.TryGetSession (serviceId, out session))
				return session as GameService;
			else
				return null;
		} else
			return null;
	}

	public void SendMessage (string serviceId, string message)
	{
		WebSocketServiceHost host = GetServiceHost (currentService);

		if (host != null) {
			host.Sessions.SendTo (message, serviceId);
		}
	}
}
