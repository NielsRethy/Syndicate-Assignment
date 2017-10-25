using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SCR_Weapon : SCR_Item
{

    public int Bullets;
    public int MaxBullets;

    public int ATTStatsIncrease = 10;
    public SCR_Character Character;
    public string WeaponFileLocation;
    public int Damage;

    public enum GunType
    {
        Gun,
        Rifle,
        Persuader
    }

    public GunType Weapon;

    public override void PickUp(SCR_Character ch)
    {
    }

    public void AddBullets(int bullets)
    {
        Bullets += bullets;

        if (Bullets > MaxBullets)
        {
            Bullets = MaxBullets;
        }
    }

}
