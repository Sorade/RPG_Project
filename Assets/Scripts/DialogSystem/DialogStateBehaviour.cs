using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogStateBehaviour : StateMachineBehaviour {
    public DialogPhase phase;
    public int phaseID;
    public int currentPhaseID;
    public int nextPhaseID;

    // Use this for initialization
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        UIManager.instance.mainText.text = phase.mainText;
        Init(animator, animatorStateInfo, layerIndex);
    }

    public virtual void Init(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {

    }
}
