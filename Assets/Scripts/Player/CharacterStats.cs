using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Stats/Character")]
public class CharacterStats : ScriptableObject
{
    public WeaponStatBlock weaponStats;
    public PlayerStats playerStats;
    public GameObject startingWeapon;
    public int startingExp;
}
