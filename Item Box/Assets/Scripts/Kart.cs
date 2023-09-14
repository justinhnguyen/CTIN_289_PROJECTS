using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kart : MonoBehaviour {

    Rigidbody rb;
    AudioSource sfx;

    [SerializeField]
    float speed;

    [SerializeField]
    Transform spawnPoint;

    GameObject heldItem = null;

    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody>();
        sfx = this.gameObject.GetComponent<AudioSource>();
    }

    void Update() {

        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other) {
        ItemBox itemBox = other.GetComponent<ItemBox>();
        if (itemBox != null) {
            sfx.Play();
            Destroy(itemBox.gameObject);
            SpawnAnItem();
        }
    }

    private void SpawnAnItem() {

        if (heldItem != null) {
            Destroy(heldItem);
        }

        GameObject itemToSpawn = PickAnItemToSpawn();
        heldItem = Instantiate(itemToSpawn, spawnPoint.transform.position, Quaternion.identity);
        heldItem.transform.SetParent(spawnPoint);

    }

    private GameObject PickAnItemToSpawn() {

        GameObject pickedItem;

        // One way to pick an item...
        PickItemFromList picker = GetComponent<PickItemFromList>();
        pickedItem = picker.PickItem();

        // Another way to pick an item...
        //PickItemFromShuffledDeck picker = GetComponent<PickItemFromShuffledDeck>();
        //pickedItem = picker.PickItem();

        // And yet another way to pick an item...
        //PickItemUsingProbability picker = GetComponent<PickItemUsingProbability>();
        //pickedItem = picker.PickItem();

        return pickedItem;

    }

}
