using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class DialogReaction : Reaction
    {
        [HideInInspector]
        public Animator animator;

        // Use this for initialization
        void Awake()
        {
            animator = GetComponentInParent<Animator>();
        }
    }
}
