using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReaction : Reaction {
    [SerializeField]
    SimpleEvent eventName;
    
    public override void React()
    {
        base.React();
        Debug.Log("End");

        EventManager.TriggerEvent(eventName);
    }
}
