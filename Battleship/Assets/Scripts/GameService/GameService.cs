using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using WebSocketSharp.Server;

public class GameService : WebSocketBehavior
{
	protected override void OnOpen ()
	{
		base.OnOpen ();
		Debug.Log ("Session started : " + this.ID);
	}

	protected override void OnMessage (MessageEventArgs e)
	{
		base.OnMessage (e);

		if (e.IsText) {
			Debug.Log ("message Recived: " + e.Data);
		}
	}

	protected override void OnClose (CloseEventArgs e)
	{
		base.OnClose (e);

		Debug.Log ("Session closed : " + e.Reason);
	}

	protected override void OnError (ErrorEventArgs e)
	{
		base.OnError (e);
		Debug.Log ("ERROR OCCURED: " + e.Message);
	}

}
