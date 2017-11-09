using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteraction : Interactable {
    public GameObject dialog;

    // When the player interacts with the item
    public override void Interact()
    {
        base.Interact();

        StartConversation();
    }

    void StartConversation()
    {
        dialog.SetActive(true);
    }
}
