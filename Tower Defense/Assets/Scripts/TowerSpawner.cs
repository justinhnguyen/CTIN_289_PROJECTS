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
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 point = new Vector2(worldPosition.x, transform.position.y);
            Collider2D col = Physics2D.OverlapPoint(point);
            if (col)
            {
                marker.SetActive(true);
                marker.transform.position = point;
            }
            else
            {
                marker.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                // No rotation applied, so set rotation to Quaternion.identity (no rotation)
                Quaternion rotation = Quaternion.identity;

                GameObject newTowerGO = Instantiate(towerPrefab, point, rotation);
                Tower newTower = newTowerGO.GetComponent<Tower>();

                gameManager.HandleTowerSpawned(newTower);
            }
        }
        else
        {
            marker.SetActive(false);
        }
    }
}