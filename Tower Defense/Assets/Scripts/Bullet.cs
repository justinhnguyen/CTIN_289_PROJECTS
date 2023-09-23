using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Handle the impact with the enemy/creep here
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.HandleKillCreep();
            }

            Destroy(other.gameObject); // Destroy the creep
            Destroy(gameObject); // Destroy the bullet
        }
    }
}