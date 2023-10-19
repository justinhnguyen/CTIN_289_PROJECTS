using System.Collections;
using UnityEngine;

public class SuplexController : MonoBehaviour
{
    private Animator _animator;
    private Transform leftHandJoint;
    private GameObject currentTarget; // The currently targeted enemy

    private void Start()
    {
        _animator = GetComponent<Animator>();
        leftHandJoint = _animator.GetBoneTransform(HumanBodyBones.LeftHand);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && currentTarget == null)
        {
            // Set the current enemy as the target
            currentTarget = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentTarget)
        {
            // Reset the target when the player exits the trigger zone
            currentTarget = null;
        }
    }

    private void Update()
    {
        if (currentTarget != null)
        {
            // Check for a condition to perform the suplex (e.g., mouse button press)
            if (Input.GetMouseButtonDown(0))
            {
                // Trigger the suplex animation
                _animator.SetTrigger("Suplex");

                // Parent the enemy to the left hand joint
                currentTarget.transform.SetParent(leftHandJoint);
                StartCoroutine(Suplex());
            }
        }
    }
    private IEnumerator Suplex()
    {
        yield return new WaitForSeconds(0.69f);

        currentTarget.transform.parent = null;
    }
}
