using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionScript : MonoBehaviour
{
    [Header("Managers")]
    public PlayerInventory playerInventory;
    public Water waterBucket;

    [Header("Watering Function")]
    public int waterAmount;
    private bool checkingWaterStatus;
    private Plant currentPlant;

    public string interactableTag = "Interactable";
    public float interactionRange = 1f;
    public KeyCode interactButton = KeyCode.E;
    public LayerMask interactableLayers;

    // Update is called once per frame
    void Update()
    {
                /*      IGNORE     */ 
        bool playerInteracts = Input.GetKeyDown(interactButton);

        /*      THIS ROOM IS UNLOCKED AFTER COLLECTING THE GARDENING TOOLS      */
        if (SceneManager.GetActiveScene().name == "Room2")
        {
            

            //If the player press their interaction button, CHECK IF THEY'RE interacting with the water bucket or plant
            if (playerInteracts)
            {
                // Vector2 offsetPosition = (Vector2) transform.position + ((Vector2)transform.up * rayOffset);
                Ray2D ray = new Ray2D(transform.position, Vector2.up);

                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, interactionRange, interactableLayers);
                if (hit.collider != null)
                {
                    // Debug.Log("Hit " + hit.transform.gameObject.name);
                    if (hit.collider.name == "WaterBucket")
                    {
                        waterAmount += waterBucket.refillWateringCan();

                        if (waterAmount > 10)
                        {
                            waterAmount = 10;
                        }

                        Debug.Log("Player has interacted with the bucket");
                    }
                    else if (hit.collider.tag == "Plant")
                    {
                        currentPlant = hit.collider.GetComponent<Plant>();
                        checkingWaterStatus = currentPlant.checkPlantStatus();

                        if (currentPlant != null)
                        {
                            if (waterAmount > 0 && checkingWaterStatus == false)    //Interacting UNWATERED plant && HAS water in watering can
                            {
                                currentPlant.WaterPlant();
                                Debug.Log(hit.collider.tag + " has been watered.");
                                waterAmount--;
                            }
                            else if (playerInteracts && checkingWaterStatus == true)   //Interacting WATERED plant
                            {
                                Debug.Log("Plant is ready to be gathered.");
                                //ACQUIRE said water plant using PLAYER INVENTORY
                            }
                            else
                            {
                                //  WOULD WANT A DIALOGUE POP-UP THAT SAYS THERE'S NOT ENOUGH WATER IN THIS WATERING CAN
                            }
                            //Debug.Log("Player has interacted with the plant");
                        }
                        
                        
                    }

                }
                // if (hit.collider.tag == "WaterBucket")
                // {

                // }
                // else if (hit.collider.tag == "Plant")
                // {
                //     if (waterAmount > 0 && checkingWaterStatus == false)    //Interacting UNWATERED plant && HAS water in watering can
                //     {
                //         plantInteraction.WaterPlant();
                //         waterAmount--;
                //     }
                //     else if (playerInteracts && plantInteraction.checkPlantStatus() == true)   //Interacting WATERED plant
                //     {
                //         //ACQUIRE said water plant using PLAYER INVENTORY
                //     }
                //     else
                //     {
                //         //  WOULD WANT A DIALOGUE POP-UP THAT SAYS THERE'S NOT ENOUGH WATER IN THIS WATERING CAN
                //     }
                // }
            }
            
        }

        if (playerInteracts)
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