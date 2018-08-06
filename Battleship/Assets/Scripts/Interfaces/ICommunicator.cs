using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommunicator
{

	string SessionId { get; set; }

	void SendMessage (string message);

	string ReciveMessage ();
}
