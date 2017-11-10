using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

[RequireComponent(typeof(ColorOnHover))]
public class Interactable : MonoBehaviour
{

    public delegate void OnInteracted(Vector3 point);
    public static OnInteracted onInteractedCallback;

    public float radius = 3f;
	public Transform interactionTransform;

    [HideInInspector]
	public bool isFocus = false;	// Is this interactable currently being focused?
    [HideInInspector]
    public Transform playerTransform;		// Reference to the player transform
    [HideInInspector]
    public bool hasInteracted = false;	// Have we already interacted with the object?

    void Update ()
	{
        CheckInteractAllowed();
    }

	// Called when the object starts being focused
	public void OnFocused (Transform newPlayerTransform)
	{
		isFocus = true;
		hasInteracted = false;
        playerTransform = newPlayerTransform;
    }

	// Called when the object is no longer focused
	public void OnDefocused ()
	{
		isFocus = false;
		hasInteracted = false;
        playerTransform = null;
	}

	// This method is meant to be overwritten
	public virtual void Interact ()
	{
		
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

    public virtual void CheckInteractAllowed()
    {
        if (isFocus)    // If currently being focused
        {
            float distance = Vector3.Distance(playerTransform.position, interactionTransform.position);
            // If we haven't already interacted and the player is close enough
            if (!hasInteracted && distance <= radius)
            {
                // Interact with the object
                hasInteracted = true;
                Interact();
            }
        }
    }
}
