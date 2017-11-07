using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reply : MonoBehaviour {
    public string text;
    public Condition[] conditions;
    public Reaction[] reactions;
    [HideInInspector]
    public int order;

    public bool CheckConditions()
    {
        Debug.Log("TEST");
        for (int i = 0; i < conditions.Length; i++)
        {
            if (!conditions[i].Check())
            {
                return false;
            } 
        }
        return true;
    }

}
