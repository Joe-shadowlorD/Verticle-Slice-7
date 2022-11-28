using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmountOfCoins : MonoBehaviour
{
    public float amountOfCoinsOwned = 0f;
    public Text coinsText;

    // Start is called before the first frame update
    void Start()
    {
        amountOfCoinsOwned = 0f;
    }

    private void Update()
    {
        coinsText.text = "amount of coins: " + amountOfCoinsOwned;
    }
}
