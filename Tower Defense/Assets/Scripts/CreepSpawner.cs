using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepSpawner : MonoBehaviour
{
    [SerializeField] float startInterval;
    [SerializeField] float minInterval;
    float interval; // Time between creep spawns
    [SerializeField] GameObject creepPrefab;
    float nextSpawn;

    public Transform[] waypoints; // Define waypoints for the path

    void Start()
    {
        interval = startInterval;
        nextSpawn = interval;
    }

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            GameObject newCreep = Instantiate(creepPrefab, transform.position, Quaternion.identity);
            Creep creepScript = newCreep.GetComponent<Creep>();

            if (creepScript != null)
            {
                // Set the waypoints for the newly spawned creep.
                creepScript.waypoints = waypoints;
            }

            interval = Mathf.Max(interval - 0.2f, minInterval);
            nextSpawn = Time.time + interval;
        }
    }
}
