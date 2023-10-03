using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float slowdownRate = 2f; // Rate at which the player slows down when "S" is held

    private bool isSlowed = false; // Track if the player is slowed

    void FixedUpdate()
    {
        if (isSlowed)
        {
            // Gradually decrease the player's forward force while "S" is held
            forwardForce -= slowdownRate * Time.deltaTime;
            forwardForce = Mathf.Max(0f, forwardForce);
        }
        else
        {
            // Add a forward force
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        // Handle left and right movement
        if (Input.GetKey("d")) // If the player is pressing the "d" key
        {
            // Add a force to the right
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a")) // If the player is pressing the "a" key
        {
            // Add a force to the left
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s"))
        {
            // The player is holding "S," so indicate that they are slowed
            isSlowed = true;
        }
        else
        {
            // The player released "S," so indicate that they are not slowed
            isSlowed = false;
        }

        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
