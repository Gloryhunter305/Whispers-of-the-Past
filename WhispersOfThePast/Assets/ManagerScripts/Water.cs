using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public int refillWaterRate;

    // Start is called before the first frame update
    public int refillWateringCan()
    {
        return refillWaterRate;
    }
}
