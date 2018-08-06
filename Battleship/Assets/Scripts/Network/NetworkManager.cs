using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
	private WebSocketClient clientConnection = null;
	private WebSocketGameServer gameServer = null;

	void Awake ()
	{
		NetworkConfig.IP = "127.0.0.1";
		NetworkConfig.PORT = "80";
		NetworkConfig.SERVICE = Meta.SERVICE;

		//clientConnection = new WebSocketClient (NetworkConfig.WebSocketServiceUrl, null);
		//clientConnection.ConnectToServer ();

		//gameServer = new WebSocketGameServer (NetworkConfig.WebSocketUrl, Meta.SERVICE);
		//gameServer.StartServer ();
	}

	// Use this for initialization
	void Start ()
	{
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		//StartCoroutine (delayUpadet ());
		//gameServer.GetServiceHost (Meta.SERVICE).Sessions.Broadcast ("Broadcast test string");

	}

	void OnDisable ()
	{
		//gameServer.StopServer ();
	}

	IEnumerator delayUpadet ()
	{
		yield return new WaitForSeconds (5);
	}
}
