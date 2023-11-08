using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon
{
    public List<WeaponData> weaponData;
}

[System.Serializable]
public class WeaponData
{
    public string name;
    public float damage;
    public float atkSpeed;
}
