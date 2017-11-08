using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPhaseReaction : Reaction {
    [SerializeField]
    int nextPhaseID;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	public override void React () {
        animator.SetInteger("currentPhase", nextPhaseID);
    }
}
