using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
	private WebSocketClient clientConnection = null;

	void Awake ()
	{
		NetworkConfig.IP = "127.0.0.1";
		NetworkConfig.PORT = "80";
		NetworkConfig.SERVICE = Meta.SERVICE;

		clientConnection = new WebSocketClient (NetworkConfig.WebSocketUrl, null);
		clientConnection.ConnectToServer ();
	}

	// Use this for initialization
	void Start ()
	{
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
