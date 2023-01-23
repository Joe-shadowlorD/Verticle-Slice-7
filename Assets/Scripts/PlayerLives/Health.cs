using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;
    public GameObject live4;
    public GameObject live5;
    public GameObject live6;
    public GameObject live7;
    public GameObject live8;
    public GameObject live9;
    public GameObject live10;

    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth == 9)
        {
            live10.SetActive(false);
        }
        if (currentHealth == 8)
        {
            live9.SetActive(false);
        }
        if (currentHealth == 7)
        {
            live8.SetActive(false);
        }
        if (currentHealth == 6)
        {
            live7.SetActive(false);
        }
        if (currentHealth == 5)
        {
            live6.SetActive(false);
        }
        if (currentHealth == 4)
        {
            live5.SetActive(false);
        }
        if (currentHealth == 3)
        {
            live4.SetActive(false);
        }
        if (currentHealth == 2)
        {
            live3.SetActive(false);
        }
        if (currentHealth == 1)
        {
            live2.SetActive(false);
        }
        if (currentHealth == 0)
        {
            live1.SetActive(false);
        }

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void Death()
    {
        loseScreen.SetActive(true);
        Destroy(gameObject);
        Time.timeScale = 0;
        currentHealth = 0;
    }
}
