﻿using UnityEngine;
using System.Collections;

public class EventHub : MonoBehaviour {

	#region Event delegates
	public delegate void VoidEvent();
	public delegate void IntegerParamEvent (int value);
	public delegate void GameObjectParamEvent(GameObject obj);
	public delegate void GameObjectIntegerParamEvent(GameObject enemy, int value);
	#endregion



	#region Events
	public event VoidEvent ExampleVoidEvent;
	public event VoidEvent KillzoneTriggered;
	public event IntegerParamEvent ExampleIntegerEvent;
	public event GameObjectParamEvent ExampleGameObjectEvent;
	public event GameObjectIntegerParamEvent ExampleCombinedEvent;
	#endregion

	#region Triggers
	public void TriggerExampleIntegerEvent(int val) {
		if(ExampleIntegerEvent != null)
			ExampleIntegerEvent (val);
	}

    public void TriggerKillzoneTriggered()
    {
        if (KillzoneTriggered != null)
            KillzoneTriggered();
    }


    //You get the idea on how this is done...
    //Generic .Invoke(...) cannot be done, as the event fields cannot be accessed from outside this class :(
    #endregion
}
