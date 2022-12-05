using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
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
