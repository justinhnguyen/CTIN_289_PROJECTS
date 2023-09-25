using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    GameObject marker;

    [SerializeField]
    GameObject towerPrefab;

    void Update()
    {
        if (gameManager.IsInTowerSpawnMode())
        {
            // Hide the default cursor
            Cursor.visible = false;

            // Set the marker's position to the mouse position
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            marker.transform.position = new Vector3(worldPosition.x, worldPosition.y, marker.transform.position.z);

            // Show the marker
            marker.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                // No rotation applied, so set rotation to Quaternion.identity (no rotation)
                Quaternion rotation = Quaternion.identity;

                GameObject newTowerGO = Instantiate(towerPrefab, marker.transform.position, rotation);
                Tower newTower = newTowerGO.GetComponent<Tower>();

                gameManager.HandleTowerSpawned(newTower);
            }
        }
        else
        {
            // Show the default cursor
            Cursor.visible = true;

            // Hide the marker
            marker.SetActive(false);
        }
    }
}