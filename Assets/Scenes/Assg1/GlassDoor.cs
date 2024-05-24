
/*
 * Author: Travis Tan
 * Date: 19/05/2024
 * Description: 
 * To check whether player has second keycard then open glass door
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassDoor : MonoBehaviour
{
    /// <summary>
    /// Flags if the door is open
    /// </summary>
    bool opened = false;

    /// <summary>
    /// Flags if the door is locked
    /// </summary>
    public bool locked = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Check whether only Player enters and whether door is NOT opened
        if (collision.gameObject.CompareTag("Player") && !opened)
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TryOpenGlassDoor(this);
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
        if (locked)
        {
            return; // Exit the method if the door is locked
        }

        // Here we are destroying the door instead of opening it
        Destroy(gameObject);
        opened = true;
    }

    public void SetLock(bool lockStatus)
    {
        // Assign the lockStatus value to the locked bool.
        locked = lockStatus;
    }
}
