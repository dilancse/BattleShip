using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerCommunicator : NetworkCommunicator
{
	private WebSocketGameServer gameServer = null;

	public ServerCommunicator ()
	{
		gameServer = new WebSocketGameServer (NetworkConfig.WebSocketUrl, Meta.SERVICE);
	}
}
