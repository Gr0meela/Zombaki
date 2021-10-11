using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponType", menuName = "Scriptable Objects/Weapon")]
public class Weapon : Pickables
{
    public float _damage;
    public int _ammunition;
    public float _cooldown;
}
