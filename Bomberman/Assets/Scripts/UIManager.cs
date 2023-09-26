using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text gameOverTextUI; // Reference to the TMP Text for game over text
    public TMP_Text replayTextUI; // Reference to the TMP Text for replay text

    public GameOver gameOverData; // Reference to the GameOver ScriptableObject

    private void Start()
    {
        // Initialize UI elements
        gameOverTextUI.text = "";
        replayTextUI.text = "";
    }

    public void ShowGameOver(string winnerName)
    {
        // Display the game over text using the winner's name
        gameOverTextUI.text = "Game Over, Player " + winnerName + " wins!";
        replayTextUI.text = "Press R to replay";

        // Show the TMP Text elements and restart button
        gameOverTextUI.gameObject.SetActive(true);
        replayTextUI.gameObject.SetActive(true);
    }

    private void Update()
    {
        // Check for the "R" key press to trigger a game replay
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReplayGame(); // Call a method to handle the game replay
        }
    }

    public void ReplayGame()
    {
        // Implement logic to reset the game state and scene
        // For example, you can reload the current scene:
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Other GameManager methods...
}
