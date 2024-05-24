
/*
 * Author: Travis Tan
 * Date: 19/05/2024
 * Description: 
 * Check for player 15 points then open door
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour
{
    /// <summary>
    /// Flags if the door is open
    /// </summary>
    bool opened = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check whether only Player enters and whether door is NOT opened
        if (collision.gameObject.CompareTag("Player") && !opened)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TryOpenDoor2(this);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the object exiting the collision has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            // Clear the locked message via the Player script
            player.DisplayLockedMessage("");
        }
    }

    ///<summary>
    /// Handles open door function
    ///</summary>
    public void OpenDoor()
    {
        // Here we are destroying the door instead of opening it
        Destroy(gameObject);
        opened = true;
    }
}
