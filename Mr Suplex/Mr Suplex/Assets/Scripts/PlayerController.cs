using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] Vector3 jumpVelocity;
    [SerializeField] Animator animator;
    CharacterController ch;

    //Jump
    [SerializeField] float jumpHeight = 1.5f;

    void Start()
    {
        ch = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        moveDirection = new Vector3(horizontal, 0, vertical);
        moveDirection *= speed;

        if (moveDirection == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("Speed", 0.5f);
        }
        else
            animator.SetFloat("Speed", 1);
        
    }
}
