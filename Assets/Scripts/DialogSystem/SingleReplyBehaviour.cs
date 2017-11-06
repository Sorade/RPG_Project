using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleReplyBehaviour : DialogStateBehaviour {
    public SingleReplyPhase phase
    {
        get { return (SingleReplyPhase)base.phase; }
        set { base.phase = value; }
    }

    public override void Init(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        UIManager.instance.replies[0].text = phase.reply;
    }

    // Update is called once per frame
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    { 
        if (UIManager.instance.selectedReply[0])
        {
            phase.animator.SetInteger("currentPhase", nextPhaseID);
        }
	}
}
