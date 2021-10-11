using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieType", menuName = "Scriptable Objects/Zombies")]
public class Zombies : ScriptableObject
{
    public string _name;
    public float _health;
    public float _speed;
    public float _power;
    public float _cooldown;
}
