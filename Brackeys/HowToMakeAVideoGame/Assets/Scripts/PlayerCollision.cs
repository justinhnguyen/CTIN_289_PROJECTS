using UnityEngine;
using UnityEngine.UI;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    public AudioSource collisionSound;
    public AudioSource pointsSound;
    public Score scoreScript;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            if (collisionSound != null)
            {
                collisionSound.Play();
            }

            movement.enabled = false;   // Disable the player's movement.
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Points"))
        {
            Debug.Log("+50");
            if (scoreScript != null)
            {
                scoreScript.IncreaseScore(50);
                pointsSound.Play();
                Destroy(other.gameObject);
            }
        }
    }
}
