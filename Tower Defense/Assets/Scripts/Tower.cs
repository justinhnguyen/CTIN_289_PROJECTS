using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

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

    // Update is called once per frame
    void Update() {
        cooldownTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Enemy") {
            if (cooldownTimer <= 0) {
                Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
                cooldownTimer = cooldownInterval;
            }
        }

    }

    public void Upgrade() {
        cooldownTimer = 0;
        cooldownInterval = upgradedCooldownInterval;
        GetComponent<SpriteRenderer>().sprite = upgradedSprite;
    }

}
