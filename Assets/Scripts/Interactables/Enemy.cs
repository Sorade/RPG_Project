using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This makes our enemy interactable. */

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable {

	CharacterStats stats;
	public RagdollManager ragdoll;
    //store a var that hold the component which determines the attack action to be performed by the player CAC or shoot
    float playerAttackRadius = 15f; //need to change that to be dependent on the player's weapon or skill equiped

    void Start ()
	{
		stats = GetComponent<CharacterStats>();
		stats.OnHealthReachedZero += Die;
	}

    private void OnDisable()
    {
        stats.OnHealthReachedZero -= Die;
    }

    // When we interact with the enemy: We attack it.
    public override void Interact()
	{
		print ("Interact");
		CharacterCombat combatManager = Player.instance.playerCombatManager;
		combatManager.Attack(stats);

        if (PlayerController.onFocusChangedCallback != null)
            PlayerController.onFocusChangedCallback.Invoke(null);

        if (Interactable.onInteractedCallback != null)
            //stops focussing this interactable
            Interactable.onInteractedCallback.Invoke(playerTransform.position);
    }

	void Die() {
		ragdoll.transform.parent = null;
		ragdoll.Setup ();
		Destroy (gameObject);
	}

    /* override the Interactable class method to check if a shoot or CAC action is to be performed and therefore
     * if the interaction should be triggered or not.*/
    public override void CheckInteractAllowed()
    {
        if (isFocus)    // If currently being focused
        {
            float distance = Vector3.Distance(playerTransform.position, interactionTransform.position);
            // If we haven't already interacted and the player is close enough
            if (!hasInteracted && distance <= radius || distance <= playerAttackRadius)
            {
                // Interact with the object
                hasInteracted = true;
                Interact();
            }
        }
    }
}
