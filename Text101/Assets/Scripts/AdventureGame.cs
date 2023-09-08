using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = ("Test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
