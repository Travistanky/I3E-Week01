
/*
 * Author: Travis Tan
 * Date: 19/05/2024
 * Description: 
 * Obstacle to minus points if player touch obstacle
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int penaltyScore = 3;

    /// <summary>
    /// Callback function for when a collision occurs
    /// </summary>
    /// <param name="collision">Collision event data</param>
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that touched the obstacle has a 'Player' tag
        if (collision.gameObject.tag == "Player")
        {
            // Look for the "Player" component on the GameObject that collided with the obstacle.
            // Decrease the player's score by the penalty amount.
            collision.gameObject.GetComponent<Player>().DecreaseScore(penaltyScore);
        }
    }
}
