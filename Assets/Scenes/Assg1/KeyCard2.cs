
/*
 * Author: Travis Tan
 * Date: 19/05/2024
 * Description: 
 * Second keycard for glass door
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCard2 : MonoBehaviour
{
    /// <summary>
    /// The glass door that this key card unlocks
    /// </summary>
    public GlassDoor linkedGlassDoor;

    private void Start()
    {
        // Check if there is a linked glass door
        if (linkedGlassDoor != null)
        {
            // Lock the glass door that is linked
            linkedGlassDoor.SetLock(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if it's the Player colliding with the keycard
        if (collision.gameObject.CompareTag("Player"))
        {
            // Tell the glass door to unlock itself.
            linkedGlassDoor.SetLock(false);
            Destroy(gameObject);
        }
    }
}
