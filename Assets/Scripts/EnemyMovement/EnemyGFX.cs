using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    private Health health;
    public AIPath aiPath;

    public int damage = 1;

    private float timer = 0;
    private float waitForNextAttack = 50f;

    private void Start()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
    }
    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if(aiPath.desiredVelocity.x == 0f && aiPath.desiredVelocity.y == 0f)
        {
            if (timer <= waitForNextAttack)
            {
                if (timer >= 1.8f)
                {
                    health.TakeDamage(damage);
                    timer = 0f;
                }
                timer += Time.deltaTime;
            }
        }
        else
        {
            timer = 0f; 
        }
    }
}
