using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStart : MonoBehaviour {
    [SerializeField]
    bool disableOnStart;

    // Use this for initialization
    void Start () {
        if (disableOnStart)
        {
            StartCoroutine(DisableWithDelay());
        }
    }
	
	IEnumerator DisableWithDelay()
    {
        yield return new WaitForEndOfFrame();
        gameObject.SetActive(false);
    }
}
