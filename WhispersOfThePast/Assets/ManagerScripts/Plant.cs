using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int minimumWatering = 2;
    public int maximumWatering = 5;
    private int wateringRequirement;

    private bool waterStatus = false;           //False = Not watered enough ***    True = Watered enough

    //private Renderer plantSaturation;

    public Sprite wateredPlant;
    private SpriteRenderer spriteRenderer;
    private PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        wateringRequirement = Random.Range(minimumWatering, maximumWatering + 1);
        Debug.Log("Watering requirement: " + wateringRequirement);

        //plantSaturation = GetComponent<Renderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void WaterPlant()
    {
        // Decrement the watering requirement
        wateringRequirement--;
        if (wateringRequirement <= 0)
        {
            Debug.Log("Plant is fully watered!");
            waterStatus = true;

            //Changing the plant's appearance
            changeSpritePlant();
        }
    }

    public void changeSpritePlant()
    {
        spriteRenderer.sprite = wateredPlant;
    }

    public void collectPlant()
    {
        playerInventory.AddFlower(this);
    }

    public void disAppearPlant()
    {
        gameObject.SetActive(false);
    }

    public bool checkPlantStatus()
    {
        if (waterStatus)
        {
            return true;
        }
        return false;

    }
}
