using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;  // Assign your ball prefab in the Unity Editor
    public float spawnInterval = 5.0f;  // Time interval in seconds
    public float launchForce = 10.0f;  // The force to apply to the ball

    private void Start()
    {
        // Start a coroutine to spawn and launch balls at regular intervals
        StartCoroutine(SpawnAndLaunchBalls());
    }

    private IEnumerator SpawnAndLaunchBalls()
    {
        while (true)
        {
            // Instantiate the ball prefab at the position of the spawner
            GameObject newBall = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            

            // Get the rigidbody of the spawned ball
            Rigidbody rb = newBall.GetComponent<Rigidbody>();

            // Check if the spawned ball has a rigidbody
            if (rb != null)
            {
                // Apply a force to launch the ball
                rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);
            }

            // Wait for the specified interval before spawning the next ball
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
