using UnityEngine;

public class EndZone : MonoBehaviour
{
    private bool playerInside = false;
    private float timer = 0f;
    public float requiredTimeInside = 10f;
    public Animator animator; // Reference to the Animator component.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            // Trigger the "FadeOut" animation when the player enters the trigger zone.
            animator.SetTrigger("FadeOutTrigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            timer = 0f; // Reset the timer when the player exits the trigger zone.
        }
    }

    private void Update()
    {
        if (playerInside)
        {
            timer += Time.deltaTime;
            if (timer >= requiredTimeInside)
            {
                // End the game or perform your game-ending logic here.
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over!"); // You can replace this with your game-ending logic.
        // You might want to show a game over screen or execute other actions.
        // To quit the application, you can use Application.Quit():
        // Application.Quit();
    }
}
