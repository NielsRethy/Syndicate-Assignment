using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Rifle : SCR_Weapon
{
    //Rifle gun class
    public SCR_Rifle()
    {
        ATTStatsIncrease = 10;
        RateOfFire = 1;
        Reload = 10;
        WeaponLocation = "Models/Guns/PREF_Rifle";
        Weapon = GunType.Rifle;
        Damage = 100;
    }

    public override void PickUp(SCR_Character ch)
    {
        Character = ch;
        Character.ActiveWeapon = this;
        Character.ATTStats = ATTStatsIncrease;
    }
}
