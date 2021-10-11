using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFist : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TurretHealth>())
        {
            other.gameObject.GetComponent<TurretHealth>().SetHealth(-5f);
        }
    }
}
