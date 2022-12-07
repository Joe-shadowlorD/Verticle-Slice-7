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

    public GameObject weapon;
    private float facing = 1f;

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
            facing = -facing;
        } else if(aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            facing = -facing;
        }

        if(aiPath.desiredVelocity.x == 0f && aiPath.desiredVelocity.y == 0f)
        {
            if (timer <= waitForNextAttack)
            {
                if (timer >= 1.8f)
                {
                    Attack();
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

    private void Attack()
    { 
        weapon.SetActive(true);
        weapon.transform.position = gameObject.transform.position + new Vector3(facing, 0f, 0f);
        health.TakeDamage(damage);
    }
}
