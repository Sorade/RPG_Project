using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogSystem
{
    public class DialogCondition : Condition
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
