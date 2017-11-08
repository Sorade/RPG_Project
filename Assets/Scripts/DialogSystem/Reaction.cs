using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaction : MonoBehaviour {
    [HideInInspector]
    public Animator animator;

	// Use this for initialization
	void Awake () {
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    public virtual void React () {
    }
}
