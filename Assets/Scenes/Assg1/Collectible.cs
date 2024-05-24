
/*
 * Author: Travis Tan
 * Date: 19/05/2024
 * Description: 
 * To collect coins and keep score
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int myScore = 5;
    public void Collected()
    {
        Debug.Log("I got collected");
        Destroy(gameObject);
    }

    /// <summary>
    /// Callback function for when a collision occurs
    /// </summary>
    /// <param name="collision">Collision event data</param>
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that
        // touched me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            // Look for the "Player" component on the GameObject that collided with me.
            // Update the player that I am the current collectible.
            collision.gameObject.GetComponent<Player>().UpdateCollectible(this);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the object that
        // stopped touching me has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            // Look for the "Player" component on the GameObject that collided with me.
            // Update the player that there is no current collectible.
            collision.gameObject.GetComponent<Player>().UpdateCollectible(null);

        }
    }

}
