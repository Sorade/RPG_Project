using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condition : MonoBehaviour {
    [HideInInspector]
    public Animator animator;

    // Use this for initialization
    void Awake()
    {
        animator = GetComponentInParent<Animator>();
    }
    // checks if the condition is met
    public virtual bool Check () {
        return true;
	}
}
