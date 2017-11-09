using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class NextPhaseReaction : DialogReaction
    {
        [SerializeField]
        int nextPhaseID;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        public override void React()
        {
            animator.SetInteger("currentPhase", nextPhaseID);
        }
    }
}
