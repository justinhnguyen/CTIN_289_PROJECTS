using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    float cooldownInterval;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    GameObject spawnPoint;

    [SerializeField]
    float upgradedCooldownInterval;

    [SerializeField]
    Sprite upgradedSprite;

    float cooldownTimer = 0;
    Transform target; // Reference to the current target (nearest creep)

    [SerializeField]
    float bulletSpeed = 5f; // Adjust the default bullet speed as needed

    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        // Fire when cooldown is ready
        if (cooldownTimer <= 0)
        {
            Shoot();
            cooldownTimer = cooldownInterval;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Set the target to the nearest enemy
            if (!target)
            {
                target = collision.transform;
            }
            else
            {
                // If a target already exists, check if the new one is closer
                float distanceToNewTarget = Vector3.Distance(transform.position, collision.transform.position);
                float distanceToCurrentTarget = Vector3.Distance(transform.position, target.position);

                if (distanceToNewTarget < distanceToCurrentTarget)
                {
                    target = collision.transform;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == target)
        {
            // If the current target exits the tower's range, reset the target
            target = null;
        }
    }

    void Shoot()
    {
        if (target)
        {
            // Calculate the direction to face the target (creep)
            Vector3 direction = target.position - transform.position;

            // Calculate the angle from the tower to the target
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Set the rotation of the tower to face the target
            transform.rotation = Quaternion.Euler(0f, 0f, -angle);

            // Instantiate the bullet at the tower's position
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Calculate the bullet's direction (normalized vector)
            Vector3 shootingDirection = direction.normalized;

            // Set the bullet's velocity in the calculated direction
            bulletRigidbody.velocity = shootingDirection * bulletSpeed;
        }
    }

    public void Upgrade()
    {
        cooldownTimer = 0;
        cooldownInterval = upgradedCooldownInterval;
        GetComponent<SpriteRenderer>().sprite = upgradedSprite;
    }
}