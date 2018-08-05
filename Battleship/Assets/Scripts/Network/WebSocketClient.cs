using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using WebSocketSharp;

public class WebSocketClient
{
	private WebSocket webSocket = null;

	public WebSocketClient (string url, string[] subProtocols)
	{
		if (!string.IsNullOrEmpty (url)) {

			//webSocket = new WebSocket ("ws://127.0.0.1:80/BattleShip");
			if (subProtocols != null && subProtocols.Length > 0)
				webSocket = new WebSocket (url, subProtocols);
			else
				webSocket = new WebSocket (url);
			webSocket.OnOpen += OnWebSocketOpen;
			webSocket.OnClose += OnWebSocketClosed;
			webSocket.OnMessage += OnMessageRecived;
			webSocket.OnError += OnErrorOccured;
			//webSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Ssl3;
			//webSocket.SslConfiguration.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback (ServerCertificateValidationCallBack);
		}
	}

	private bool ServerCertificateValidationCallBack (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		return true;
	}

	private void OnErrorOccured (object sender, ErrorEventArgs e)
	{
		Debug.Log ("ERROR OCCURED: " + e.Message);
	}

	private void OnMessageRecived (object sender, MessageEventArgs e)
	{
		if (e.IsText) {
			Debug.Log ("message Recived: " + e.Data);
		}
	}

	private void OnWebSocketClosed (object sender, CloseEventArgs e)
	{
		Debug.Log ("Websockt closed : " + e.Reason);
	}

	private void OnWebSocketOpen (object sender, System.EventArgs e)
	{
		Debug.Log ("Websockt opend");
	}

	public void ConnectToServer ()
	{
		webSocket.Connect ();
	}

	public void CloseConnection ()
	{
		webSocket.Close (CloseStatusCode.Normal);
	}

	public void SendMessage (string message)
	{
		webSocket.Send (message);
	}
}
