using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemFromShuffledDeck : MonoBehaviour {

    [SerializeField]
    GameObject[] itemsToPickFrom;

    int currentIndex = 0;

    private void Start() {
        ShuffleItems();
    }

    public GameObject PickItem() {

        if (currentIndex >= itemsToPickFrom.Length) {
            ShuffleItems();
            currentIndex = 0;
        }

        GameObject pickedItem = itemsToPickFrom[currentIndex];
        currentIndex += 1;
        return pickedItem;

    }

    private void ShuffleItems() {

        for (int i = 0; i < itemsToPickFrom.Length; ++i) {

            // Randomly pick an index of the array to swap this element with
            int indexToSwapWith = Random.Range(0, itemsToPickFrom.Length);

            // Swap the two elements
            GameObject temp = itemsToPickFrom[indexToSwapWith];
            itemsToPickFrom[indexToSwapWith] = itemsToPickFrom[i];
            itemsToPickFrom[i] = temp;
        
        }
    }

}
