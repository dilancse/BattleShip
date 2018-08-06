using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NetworkConfig
{
	public static string IP = "127.0.0.1";

	public static string PORT = "80";

	public static string SUB_PROTOCOL = "GamePlayProtocol";

	public static string SERVICE = "/BattleShip";

	public static string WebSocketUrl {
		get{ return Meta.WS_SCHEME + IP + ":" + PORT; }
	}

	public static string SecureWebSocketUrl {
		get{ return Meta.WSS_SCHEME + IP + ":" + PORT; }
	}

	public static string WebSocketServiceUrl {
		get{ return Meta.WS_SCHEME + IP + ":" + PORT + SERVICE; }
	}

	public static string SecureWebSocketServiceUrl {
		get{ return Meta.WSS_SCHEME + IP + ":" + PORT + SERVICE; }
	}
}
