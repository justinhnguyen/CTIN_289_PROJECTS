using UnityEngine;
using System.Collections;

public class GlobalStateManager : MonoBehaviour
{
    private int deadPlayers = 0;
    private int deadPlayerNumber = -1;

    public UIManager uiManager; // Reference to the GameManager script.

    public void PlayerDied(int playerNumber)
    {
        deadPlayers++;

        if (deadPlayers == 1)
        {
            deadPlayerNumber = playerNumber;
            Invoke("CheckPlayersDeath", .3f);
        }
    }

    void CheckPlayersDeath()
    {
        if (deadPlayers == 1)
        {
            string winnerName = (deadPlayerNumber == 1) ? "2" : "1";
            Debug.Log("Player " + winnerName + " is the winner!");

            // Set the game over text and replay text and show UI elements.
            uiManager.ShowGameOver(winnerName);

            // You can also assign the game over text to the ScriptableObject if needed:
            // gameManager.gameOverData.GameOverText = "Player " + winnerName + " wins!";
        }
        else
        {
            Debug.Log("The game ended in a draw!");
        }
    }
}