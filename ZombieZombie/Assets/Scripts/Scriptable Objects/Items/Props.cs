using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PropType", menuName = "Scriptable Objects/Props")]
public class Props : ScriptableObject
{
    public string _name;
    public float _health;
    public float _speed;
    public float _power;
    public float _explosionPower;
    public float _cooldown;
}

