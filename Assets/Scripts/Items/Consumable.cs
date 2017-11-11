using UnityEngine;

/* An Item that can be consumed. So far that just means regaining health */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Consumable")]
public class Consumable : Item {

	public int healthGain;		// How much health?

    //public Effect[] effects; will be the effects applied when the item is consumed

	// This is called when pressed in the inventory
	public override void Use()
	{
		// Heal the player
		PlayerStats playerStats = Player.instance.playerStats;
		playerStats.Heal(healthGain);

		Debug.Log(name + " consumed!");

		RemoveFromInventory();	// Remove the item after use
	}

    /* Implementation compatible with use of effects
    public override void Use()
    {
        // Apply all effects
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Apply();
        }

        Debug.Log(name + " consumed!");

        RemoveFromInventory();  // Remove the item after use
    }*/

}
