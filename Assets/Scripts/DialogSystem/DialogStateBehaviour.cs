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
        phase.SetActiveReplies();
        Init(animator, animatorStateInfo, layerIndex);
    }

    public virtual void Init(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {

    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        for (int i = 0; i < UIManager.instance.selectedReply.Length; i++)
        {
            if (UIManager.instance.selectedReply[i])
            {
                phase.replies[i].TriggerReactions();
            }
        }
    }
}
