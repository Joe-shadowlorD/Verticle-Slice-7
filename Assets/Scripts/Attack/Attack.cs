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

    void Start()
    {
        attack.SetActive(false);
    }

    void Update()
    {
        if (Input.GetAxisRaw("Attack") >0 && timer >= reloadtime)
        {
            attack.SetActive(true);
            timer = 0;
            attack.transform.localPosition = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
            Vector3 dir = attack.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.x, -dir.y) * Mathf.Rad2Deg;
            attack.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else if( timer>= attackDuration)
        {
            attack.SetActive(false);
        }
        timer += Time.deltaTime;
    }
}
