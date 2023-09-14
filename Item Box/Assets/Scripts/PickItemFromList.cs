using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemFromList : MonoBehaviour {

    [SerializeField]
    GameObject[] itemsToPickFrom;

    public GameObject PickItem() {
        return itemsToPickFrom[Random.Range(0, itemsToPickFrom.Length)];
    }

}
