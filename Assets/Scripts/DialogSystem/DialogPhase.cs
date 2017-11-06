using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Dialog))]
public class DialogPhase : MonoBehaviour
{
    public int phaseID;
    public string nameOfMSB;
    [TextArea(1,10)]
    public string mainText;
    [HideInInspector]
    public Animator animator;    // Reference to the Animator component on this gameobject.
    [HideInInspector]
    public DialogStateBehaviour dialogState;    // Reference to a single StateMachineBehaviour.
    [HideInInspector]
    public Dialog dialog;


    void Awake()
    {
        // Find a reference to the Animator component in Awake since it exists in the scene.
        animator = GetComponent<Animator>();
    }


    /*void Start()
    {
        // Find a reference to the ExampleStateMachineBehaviour in Start since it might not exist yet in Awake.
        dialogState = animator.GetBehaviour<DialogStateBehaviour>();

        // Set the StateMachineBehaviour's reference to an ExampleMonoBehaviour to this.
        dialogState.phase = this;
    }*/
}
