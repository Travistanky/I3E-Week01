
/*
 * Author: Travis Tan
 * Date: 19/05/2024
 * Description: 
 * Contain functions like increase score and decrease score for Player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Public fields for UI elements
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lockedText;
    public Image lockedImage;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI finalText;
    public TextMeshProUGUI winText;
    public Image winImage;

    // Private fields for player state
    int currentScore = 0;
    public int remainingCoins = 8;
    Door currentDoor;
    Collectible currentCollectible;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure winText and winImage are hidden at the start
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }

        if (winImage != null)
        {
            winImage.gameObject.SetActive(false);
        }
    }

    // Method to increase the player's score
    public void IncreaseScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = "Score: " + currentScore.ToString();
        remainingCoins--;
        UpdateCoinText();
    }

    // Method to decrease the player's score
    public void DecreaseScore(int scoreToSubtract)
    {
        currentScore -= scoreToSubtract;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    // Method to get the current score
    public int GetScore()
    {
        return currentScore;
    }

    // Method to update the current door reference
    public void UpdateDoor(Door newDoor)
    {
        currentDoor = newDoor;
    }

    // Method to update the current collectible reference
    public void UpdateCollectible(Collectible newCollectible)
    {
        currentCollectible = newCollectible;
    }

    // Method to display a locked message
    public void DisplayLockedMessage(string message)
    {
        lockedText.text = message;
        lockedImage.gameObject.SetActive(!string.IsNullOrEmpty(message));
    }

    // Method to display a final message
    public void DisplayFinalMessage(string message)
    {
        if (finalText == null)
        {
            Debug.LogError("finalText is not assigned in the Inspector.");
        }
        if (lockedImage == null)
        {
            Debug.LogError("lockedImage is not assigned in the Inspector.");
        }

        finalText.text = message;
        finalText.gameObject.SetActive(!string.IsNullOrEmpty(message));
        lockedImage.gameObject.SetActive(!string.IsNullOrEmpty(message));
    }

    // Method to attempt opening a Door2 instance
    public void TryOpenDoor2(Door2 door)
    {
        if (GetScore() >= 15)
        {
            door.OpenDoor();
        }
        else
        {
            DisplayLockedMessage("You need 15 points to open this door");
        }
    }

    // Method to attempt opening a GlassDoor instance
    public void TryOpenGlassDoor(GlassDoor door)
    {
        if (door.locked)
        {
            DisplayLockedMessage("You do not have the orange keycard yet");
        }
        else
        {
            door.OpenDoor();
        }
    }

    // Method to attempt opening a FinalDoor instance
    public void TryOpenFinalDoor(FinalDoor door)
    {
        if (GetScore() >= door.requiredPoints)
        {
            door.UnlockDoor(); // Unlock the door if the player has enough points
            door.OpenFinalDoor();
        }
        else
        {
            DisplayFinalMessage("You need 35 points to go through the final door");
        }
    }

    // Method to display the win message
    public void DisplayWinMessage()
    {
        if (winText != null)
        {
            winText.text = "Congratulations! You have won!!";
            winText.gameObject.SetActive(true);
        }

        if (winImage != null)
        {
            winImage.gameObject.SetActive(true);
        }
    }

    // Method to handle player interactions
    void OnInteract()
    {
        if (currentDoor != null)
        {
            currentDoor.OpenDoor();
            currentDoor = null;
        }

        if (currentCollectible != null)
        {
            Debug.Log("Interacting with collectible: " + currentCollectible.gameObject.name);
            IncreaseScore(currentCollectible.myScore);
            currentCollectible.Collected();
            currentCollectible = null;
        }
    }

    // Method to update the coin text UI
    void UpdateCoinText()
    {
        coinText.text = "Coins Remaining: " + remainingCoins.ToString();
    }
}
