using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    public AmountOfCoins amountOfCoins;
    private bool iscollected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!iscollected)
        {
            Destroy(gameObject);
            amountOfCoins.amountOfCoinsOwned += 1f;
            iscollected = true;
        }
    }
}
