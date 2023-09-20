using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Creep : MonoBehaviour
    {
        public Transform[] waypoints;
        public float moveSpeed = 5f;

        public int currentWaypointIndex = 0;

        private void Start()
        {
            // Initialize the creep's position to the first waypoint.
            transform.position = waypoints[0].position;
        }

        private void Update()
        {
            if (currentWaypointIndex < waypoints.Length)
            {
                // Move the creep towards the current waypoint.
                Vector3 targetPosition = waypoints[currentWaypointIndex].position;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                // Check if the creep has reached the current waypoint.
                if (transform.position == targetPosition)
                {
                    currentWaypointIndex++;
                }
            }
            else
            {
                // Creep has reached the end of the path, you can destroy it or handle it in another way.
                Destroy(gameObject);
            }
        }
    }