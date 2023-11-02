using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Camera gameCamera; // assign the camera in the inspector
    public float moveSpeed = 5f;
    public float acceleration = 2f; // increase in speed per second
    public float deceleration = 10f; // decrease in speed per second
    public Transform childObjectToRotate; // assign the child object in the inspector

    private Vector3 moveDirection;
    private float currentSpeed;
    private bool isMoving;
    public Animator myAC;

    private void Start()
    {
        myAC = GetComponentInChildren<Animator>();
        moveDirection = Vector3.zero;
        currentSpeed = 0f;
        isMoving = false;
    }

    private void Update()
    {
        myAC.SetFloat("Speed", currentSpeed);
        // get input axes
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // determine if the player is moving
        isMoving = (horizontalInput != 0f || verticalInput != 0f);

        // get camera forward and right vectors
        Vector3 cameraForward = gameCamera.transform.forward;
        Vector3 cameraRight = gameCamera.transform.right;

        // project camera vectors onto horizontal plane
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // calculate movement direction relative to camera
        moveDirection = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;

        // rotate child object towards movement direction
        if (childObjectToRotate != null && moveDirection != Vector3.zero)
        {
            childObjectToRotate.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
        }

        // ramp up or down speed based on movement
        if (isMoving)
        {
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration * Time.deltaTime, 0f, moveSpeed);
        }
        else
        {
            currentSpeed = Mathf.Clamp(currentSpeed - deceleration * Time.deltaTime, 0f, moveSpeed);
        }

        // move character
        transform.position += moveDirection * currentSpeed * Time.deltaTime;
    }
}
