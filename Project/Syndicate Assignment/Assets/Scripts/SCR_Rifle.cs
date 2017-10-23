using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Rifle : SCR_Weapon
{
    public SCR_Rifle()
    {
        ATTStatsIncrease = 10;
        RateOfFire = 1;
        Reload = 10;
        WeaponLocation = "Models/Guns/PREF_Rifle";
        Weapon = GunType.Rifle;
    }

    public override void PickUp(SCR_Character ch)
    {
        Character = ch;
        Character.ActiveWeapon = this;
        Character.ATTStats = ATTStatsIncrease;
    }
}
