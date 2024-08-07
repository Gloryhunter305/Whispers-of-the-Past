using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    /*  Managers    */
    public PlayerInventory playerInventory;
    public KeyCode interactButton = KeyCode.E;
    
    // The tag for the items that can be interacted with
    public string interactableTag = "Interactable";
    public float interactionRange = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactButton))
        {
            // Check if there are any interactable items within range
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactionRange);

            // Check each hit to see if it's an interactable item
            foreach (Collider2D hit in hits)
            {
                if (hit.gameObject.tag == interactableTag)
                {
                    // Interact with the item
                    InteractWithItem(hit.gameObject);
                    playerInventory.AddItem("Coin", 1);

                    //Where the dialogue for the game should be
                    hit.gameObject.SetActive(false);
                }
            }
        }
    }

    // Interact with the item
    void InteractWithItem(GameObject item)
    {
        // Perform an action when the player interacts with the item
        Debug.Log("Player interacted with " + item.name);
    }
}