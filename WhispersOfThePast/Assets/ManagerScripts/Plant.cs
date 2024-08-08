using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int minimumWatering = 2;
    public int maximumWatering = 5;
    private int wateringRequirement;

    private bool waterStatus = false;           //False = Not watered enough ***    True = Watered enough

    private Renderer plantSaturation;

    // Start is called before the first frame update
    void Start()
    {
        wateringRequirement = Random.Range(minimumWatering, maximumWatering + 1);
        Debug.Log("Watering requirement: " + wateringRequirement);

        plantSaturation = GetComponent<Renderer>();
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
            plantSaturation.material.color = Color.green;
        }
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
