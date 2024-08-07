using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    // Reference to the player's inventory script
    public PlayerInventory playerInventory;

    // Name of the item required to unlock the door
    public string requiredItemName;

    // Count of the item required to unlock the door
    public int requiredItemCount;

    // Name of the next scene to load
    public string nextSceneName;

    // Function to check if the player can unlock the door
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the player has the required item and count
            if (playerInventory.HasItem(requiredItemName, requiredItemCount))
            {
                // Load the next scene
                SceneManagerScript.instance.LoadScene(nextSceneName);
            }
        }
    }
}
