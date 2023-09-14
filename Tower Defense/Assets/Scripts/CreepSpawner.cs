using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepSpawner : MonoBehaviour {

    [SerializeField]
    float startInterval;

    [SerializeField]
    float minInterval;

    float interval; // Time between creep spawns

    [SerializeField]
    GameObject creepPrefab;

    float nextSpawn;

    // Start is called before the first frame update
    void Start() {

        interval = startInterval;
        nextSpawn = interval;

    }

    // Update is called once per frame
    void Update() {

        if (Time.time >= nextSpawn) {

            GameObject.Instantiate(creepPrefab, this.transform.position, Quaternion.identity);

            interval = Mathf.Max(interval - 0.2f, minInterval);            
            nextSpawn = Time.time + interval;

        }

    }

}
