using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour
{
    private float prefX;
    public SpriteRenderer Sr;
    private void Update()
    {
        if (transform.position.x != prefX)
        {
            Sr.flipX = transform.position.x < prefX;
        }
        prefX = transform.position.x;
    }
}
