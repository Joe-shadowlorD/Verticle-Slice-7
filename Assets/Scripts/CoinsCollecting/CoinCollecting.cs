using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecting : MonoBehaviour
{
    private AmountOfCoins amountOfCoins;
    private CoinsToAdd coinsToAdd;
    public bool isCollected = false;
    private bool collectedMore = false;

    private float time = 0;
    private float endTime = 2f;

    private void Start()
    {
        amountOfCoins = GameObject.Find("EventSystem").GetComponent<AmountOfCoins>();
        coinsToAdd = GameObject.Find("EventSystem").GetComponent<CoinsToAdd>();
        coinsToAdd.coinsCollected = 0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCollected)
        {
            gameObject.transform.position = new Vector3(1000f, 1000f, 0f);
            coinsToAdd.coinsCollected += 1f;
            coinsToAdd.coinsToAddText.material.color = Color.white;
            isCollected = true;
        }
    }

    private void Update()
    {
        if (isCollected)
        {
            if (time <= endTime)
            {
                if (time >= 1.8f)
                {
                    if(coinsToAdd.coinsCollected >= 0)
                    {
                        coinsToAdd.coinsCollected--;
                        amountOfCoins.amountOfCoinsOwned++;
                    }
                    if(coinsToAdd.coinsCollected <= 0)
                    {
                        coinsToAdd.coinsToAddText.material.color = Color.clear;
                    }
                    Destroy(gameObject);
                    time = 0f;
                }
                time += Time.deltaTime;
            }
        }

        if (collectedMore)
        {
            time = 0f;
            collectedMore = false;
        }
    }
}
