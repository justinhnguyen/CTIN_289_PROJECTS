using UnityEngine;

public class PlayerCollision : MonoBehaviour 
{
	
	public PlayerMovement movement;     
	public AudioSource collisionSound;
	public AudioSource pointsSound;
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
