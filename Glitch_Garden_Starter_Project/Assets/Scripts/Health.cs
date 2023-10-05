using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;
    Vector2 offset = new Vector2(-0.6f, 0f);

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX)
        {
            return;
        }

        Vector3 deathVFXPosition = (Vector2)transform.position + offset;
        GameObject deathVFXObject = Instantiate(deathVFX, deathVFXPosition, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }
}
