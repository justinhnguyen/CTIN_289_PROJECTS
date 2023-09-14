using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Enemy") {
            
            GameManager gameManager = GameObject.FindObjectOfType<GameManager>();
            gameManager.HandleKillCreep();

            Destroy(collision.gameObject);
            Destroy(gameObject);

        }

    }

}
