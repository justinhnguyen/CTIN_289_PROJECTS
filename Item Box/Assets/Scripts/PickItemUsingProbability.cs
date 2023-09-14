using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemUsingProbability : MonoBehaviour {

    [SerializeField]
    GameObject[] itemsToPickFrom;

    [SerializeField]
    AnimationCurve probabilityCurve;

    public GameObject PickItem() {

        float probabilityResult = probabilityCurve.Evaluate(Random.value);
        float scaledResult = probabilityResult * itemsToPickFrom.Length;
        int indexResult = Mathf.FloorToInt(scaledResult);

        return itemsToPickFrom[indexResult];

    }

}
