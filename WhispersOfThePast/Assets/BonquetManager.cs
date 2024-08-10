using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonquetManager : MonoBehaviour
{

    public PlayerInventory playerInventory;
    private int requiredWateredPlants = 5;

    public Sprite bonquet;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the player has the required item and count
            if (playerInventory.countFlowers() >= requiredWateredPlants)
            {
                Debug.Log(playerInventory.countFlowers());
                appearBonquet();
            }
        }
    }

    public void appearBonquet()
    {
        spriteRenderer.sprite = bonquet; 
    }
}
