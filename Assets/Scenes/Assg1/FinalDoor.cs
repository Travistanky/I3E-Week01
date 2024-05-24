
/*
 * Author: Travis Tan
 * Date: 19/05/2024
 * Description: 
 * Check whether players have 35 points before passing final door
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public int requiredPoints = 35;
    private bool isLocked = true;

    /// <summary>
    /// Opens the final door if the player has enough points.
    /// </summary>
    public void OpenFinalDoor()
    {
        if (!isLocked)
        {
            Debug.Log("Final door opened");
            // Implement door opening logic, e.g., play animation, disable collider, etc.
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("The door is still locked.");
        }
    }

    /// <summary>
    /// Unlocks the final door.
    /// </summary>
    public void UnlockDoor()
    {
        isLocked = false;
    }

    /// <summary>
    /// Callback function for when a collision occurs.
    /// </summary>
    /// <param name="collision">Collision event data</param>
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that touched me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.TryOpenFinalDoor(this);
            }
        }
    }

    /// <summary>
    /// Callback function for when a collision ends.
    /// </summary>
    /// <param name="collision">Collision event data</param>
    private void OnCollisionExit(Collision collision)
    {
        // Check if the object that stopped touching me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.DisplayFinalMessage(string.Empty);
            }
        }
    }
}
