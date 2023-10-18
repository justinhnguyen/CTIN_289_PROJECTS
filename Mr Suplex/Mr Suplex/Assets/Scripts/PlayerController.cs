using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float jumpForce = 5.0f;

    private bool isRunning = false;
    private bool isGrounded = true;
    private Rigidbody rb;
    [SerializeField] Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access the Rigidbody component using GetComponent
    }

    void Update()
    {
        // Check if the player is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Walking and Running
        float moveSpeed = isRunning ? runSpeed : walkSpeed;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput) * moveSpeed;

        // Update the animator parameters for speed
        float playerSpeed = Mathf.Sqrt(horizontalInput * horizontalInput + verticalInput * verticalInput);
        animator.SetFloat("HorizontalSpeed", horizontalInput * playerSpeed);
        animator.SetFloat("VerticalSpeed", verticalInput * playerSpeed);

        // Toggle running
        if (Input.GetButtonDown("Run"))
        {
            isRunning = !isRunning;
        }

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump");
        }

        // Apply movement
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }
}
