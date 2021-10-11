using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    [SerializeField] private Turret turret;
    void Awake()
    {
        turret = this.GetComponentInParent<Turret>();
    }
    public void SetHealth(float damage)
    {
        turret.SetHealth(damage);
    }
}
