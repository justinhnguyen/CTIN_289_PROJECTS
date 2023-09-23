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
            Debug.Log(waypoints.Length);
            transform.position = waypoints[0].transform.position;

        }

        private void Update()
        {
            if (currentWaypointIndex < waypoints.Length)
            {
                // Move the creep towards the current waypoint.
                Vector3 targetPosition = waypoints[currentWaypointIndex].transform.position;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            else
            {
                // Creep has reached the end of the path, you can destroy it or handle it in another way.
                Destroy(gameObject);
            }
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the creep has reached the current waypoint.
        if (collision.gameObject.tag == "Waypoint")
        {
            currentWaypointIndex++;
        }
    }

}