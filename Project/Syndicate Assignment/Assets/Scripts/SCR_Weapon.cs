using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SCR_Weapon : SCR_Item
{

    private int _bullets;

    public int ATTStatsIncrease = 10;
    public float RateOfFire = 1;
    public int Reload = 10;
    public SCR_Character Character;
    public string WeaponLocation;

    public enum GunType
    {
        Gun,
        Rifle,
        Persuader
    }

    public GunType Weapon;

    public override void PickUp(SCR_Character ch)
    {
        //_pickupObject = obj;
    }

}
