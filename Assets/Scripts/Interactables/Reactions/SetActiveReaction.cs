using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveReaction : Reaction {
    [SerializeField]
    bool setActive;
    [SerializeField]
    GameObject objectToSet;

    public override void React()
    {
        base.React();
        Debug.Log("disable conversation");
        objectToSet.SetActive(setActive);
    }
}
