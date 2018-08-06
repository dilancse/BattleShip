using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientCommunicator : NetworkCommunicator
{
	private WebSocketClient clientConnection = null;

	public ClientCommunicator ()
	{
		clientConnection = new WebSocketClient (NetworkConfig.WebSocketServiceUrl, null);
	}
}
