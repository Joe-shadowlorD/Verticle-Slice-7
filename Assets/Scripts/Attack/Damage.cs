using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Damage : MonoBehaviour
{    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {

        }
    }
}
