using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reply : MonoBehaviour {
    public string text;
    [HideInInspector]
    public Condition[] conditions;
    [HideInInspector]
    public Reaction[] reactions;
    [HideInInspector]
    public int order;
    [HideInInspector]
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        conditions = GetComponentsInChildren<Condition>();
        reactions = GetComponentsInChildren<Reaction>();
    }

    public bool CheckConditions()
    {
        for (int i = 0; i < conditions.Length; i++)
        {
            if (!conditions[i].Check())
            {
                return false;
            } 
        }
        //will also return true if no conditions are present
        return true;
    }

    public void TriggerReactions()
    {
        for (int i = 0; i < reactions.Length; i++)
        {
            reactions[i].React();
        }
    }

}
