using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Dialog : MonoBehaviour {

    public DialogPhase[] phases;
    [HideInInspector]
    public Animator animator;    // Reference to the Animator component on this gameobject.
    private DialogStateBehaviour[] phaseBehaviours;


    // Use this for initialization
    void Awake () {
        // Find a reference to the Animator component in Awake since it exists in the scene.
        animator = GetComponent<Animator>();
        phaseBehaviours = animator.GetBehaviours<DialogStateBehaviour>();
        phases = GetComponentsInChildren<DialogPhase>();
        SetUpDialog();
    }

    // Update is called once per frame
    public void SetPhaseBehaviour (DialogPhase phase) {
        for (int i = 0; i < phaseBehaviours.Length; i++)
        {
            if (phaseBehaviours[i].phaseID == phase.phaseID)
            {
                phase.dialogState = phaseBehaviours[i];
                phaseBehaviours[i].phase = phase;
                Debug.Log("Phase " + phase.nameOfMSB+ " with ID = "+phase.phaseID+"  linked to phase behaviour with ID = "+ phase.dialogState.phaseID);
            }            
        }
	}

    void SetUpDialog()
    {
        for (int i = 0; i < phases.Length; i++)
        {
            SetPhaseBehaviour(phases[i]);
        }
    }
}
