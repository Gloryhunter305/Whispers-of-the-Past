using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // Dictionary to store the player's items and their counts
    private Dictionary<string, int> items = new Dictionary<string, int>();
    public List<Plant> flowers = new List<Plant>();


    // Function to add an item to the player's inventory
    public void AddItem(string itemName, int count)
    {
        if (items.ContainsKey(itemName))
        {
            items[itemName] += count;
        }
        else
        {
            items.Add(itemName, count);
        }
    }

    public void AddFlower(Plant plant)
    {
        flowers.Add(plant);
    }

    public int countFlowers()
    {
        return flowers.Count;
    }

    // Function to check if the player has a specific item and count
    public bool HasItem(string itemName, int requiredCount)
    {
        return items.ContainsKey(itemName) && items[itemName] >= requiredCount;
    }
}
