using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCar : MonoBehaviour
{
    public Transform[] waypoints; // Define waypoints for the path
    public float moveSpeed = 5.0f; // Adjust this speed as needed
    private int currentWaypointIndex = 0;

    private void Start()
    {
        if (waypoints.Length > 0)
        {
            // Initialize the car's position to the first waypoint.
            transform.position = waypoints[currentWaypointIndex].position;
        }
    }

    private void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // Move the car towards the current waypoint.
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Rotate the car to face the current waypoint.
            transform.LookAt(targetPosition);

            // Check if the car has reached the current waypoint.
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                // Move to the next waypoint.
                currentWaypointIndex++;
            }
        }
    }
}
