using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinsToAdd : MonoBehaviour
{
    public Text coinsToAddText;
    public float coinsCollected;

    // Start is called before the first frame update
    void Start()
    {
        coinsCollected = 0f;
        coinsToAddText.material.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        coinsToAddText.text = "+" + coinsCollected;
    }
}
