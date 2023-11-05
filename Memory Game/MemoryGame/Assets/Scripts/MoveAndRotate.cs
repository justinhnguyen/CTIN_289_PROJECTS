using System.Collections;
using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public float moveDistance = 5.0f;  // Set the forward movement distance
    public float rotationAngle = 180.0f;  // Set the rotation angle
    public float moveSpeed = 2.0f;  // Set the movement speed
    public float rotationSpeed = 90.0f;  // Set the rotation speed (degrees per second)

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // Start the movement and rotation Coroutine
        StartCoroutine(MoveAndRotateObject());
    }

    private IEnumerator MoveAndRotateObject()
    {
        while (true)
        {
            // Move forward
            float distanceMoved = 0;
            Vector3 targetPosition = transform.position + transform.forward * moveDistance;

            while (distanceMoved < moveDistance)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
                distanceMoved += step;
                yield return null;
            }

            // Rotate 180 degrees
            Quaternion targetRotation = originalRotation * Quaternion.Euler(0, 180, 0);
            float rotationProgress = 0;

            while (rotationProgress < 1)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationProgress);
                rotationProgress += Time.deltaTime * (rotationSpeed / 180.0f);
                yield return null;
            }

            // Return to the original position
            distanceMoved = 0;
            while (distanceMoved < moveDistance)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);
                distanceMoved += step;
                yield return null;
            }

            // Rotate back to the original rotation
            float rotationProgressBack = 0;
            while (rotationProgressBack < 1)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, rotationProgressBack);
                rotationProgressBack += Time.deltaTime * (rotationSpeed / 180.0f);
                yield return null;
            }
        }
    }
}
