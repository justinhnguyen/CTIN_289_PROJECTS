using UnityEngine;

public class PlayerCollision : MonoBehaviour 
{
	
	public PlayerMovement movement;     
	public AudioSource collisionSound;
	public Score scoreScript;
	
	void OnCollisionEnter (Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
			if (collisionSound != null)
            {
				collisionSound.Play();
            }

			movement.enabled = false;   // Disable the players movement.
			FindObjectOfType<GameManager>().EndGame();
		}
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Points"))
        {
            if (scoreScript != null)
            {
                // Increase the score by 50 points
                scoreScript.IncreaseScore(50);

                // Destroy the collected points (coins)
                Destroy(other.gameObject);
            }
        }
    }
}
