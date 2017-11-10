using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionReaction : Reaction {
    [SerializeField]
    GameObject interactableObject;
    Interactable interactable;

	void Start () {
        interactable = interactableObject.GetComponent<Interactable>();
    }

    public override void React()
    {
        interactable.Interact();
    }
}
