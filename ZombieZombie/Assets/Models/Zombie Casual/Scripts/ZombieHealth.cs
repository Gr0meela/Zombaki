using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField] private Zombie zombie;
    void Awake()
    {
        zombie = this.GetComponentInParent<Zombie>();
    }
    public void SetHealth(float damage)
    {
        zombie.SetHealth(damage);
    }
}
