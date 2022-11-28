using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool attacking;
    public GameObject attack;
    public int reloadtime;
    private float timer;
    public float attackDuration;
    public bool isattacking;

    void Start()
    {
        attack.SetActive(false);
    }

    void Update()
    {
        if (Input.GetAxisRaw("Attack") >0 && timer >= reloadtime)
        {
            isattacking = true;
            timer = 0;
            if(Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical") != 0)
            {
                attack.transform.localPosition = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
            }
            else
            {
                attack.transform.localPosition = new Vector3(1, 0, 0);
            }
            Vector3 dir = attack.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.x, -dir.y) * Mathf.Rad2Deg;
            attack.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else if( timer>= attackDuration)
        {
            isattacking = false;
        }
        timer += Time.deltaTime;
        attack.SetActive(isattacking);

    }
}
