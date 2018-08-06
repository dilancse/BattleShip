using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkCommunicator : ICommunicator
{
	public string SessionId { get; set; }

	public virtual void SendMessage (string message)
	{
		
	}

	public virtual string ReciveMessage ()
	{
		return string.Empty;
	}
}
