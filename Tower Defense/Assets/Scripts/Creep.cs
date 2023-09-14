using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep : MonoBehaviour {

    [SerializeField]
    float speed;

    [SerializeField]
    GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        // If the creep collides with the player's base, instantiate an explosion.
        if (collision.gameObject.name == "Home Zone") {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

}

