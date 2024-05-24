/*
 * Author: Elyas Chua-Aziz
 * Date: 06/05/2024
 * Description: 
 * The door that opens when the player is near it and presses the interact button.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /// <summary>
    /// Flags if the door is open
    /// </summary>
    bool opened = false;

    /// <summary>
    /// Flags if the door is locked
    /// </summary>
    bool locked = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check whether only Player enter and whether door is NOT opened
        if (other.gameObject.tag == "Player" && !opened)
        {
            other.gameObject.GetComponent<Player>().UpdateDoor(this);
            if (!locked)
            {
                OpenDoor();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger has the "Player" tag
        if (other.gameObject.tag == "Player")
        {
            // If it is the player, update the player that there is no door
            other.gameObject.GetComponent<Player>().UpdateDoor(null);
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

        // Vector3 is x y z
        // Create new Vector3 and store current rotation of door
        // Must store in new Vector than can change rotation

        Vector3 newRotation = transform.eulerAngles;

        // Add 90 degrees to y axis rotation

        newRotation.y += 90f;

        //Assign the new rotation to transform

        transform.eulerAngles = newRotation;

        opened = true;
    }

    public void SetLock(bool lockStatus)
    {
        // Assign the lockStatus value to the locked bool.
        locked = lockStatus;
    }
}
