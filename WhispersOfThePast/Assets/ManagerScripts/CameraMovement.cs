using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // The player to follow
    public Transform player;

    // The offset from the player to position the camera
    public Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        // Set the camera's position to follow the player
        transform.position = player.position + offset;
    }
}
