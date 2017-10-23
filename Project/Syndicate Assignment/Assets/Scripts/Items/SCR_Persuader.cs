using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Persuader : SCR_Weapon
{
    //Persuader gun class
    public SCR_Persuader()
    {
        ATTStatsIncrease = 10;
        RateOfFire = 1;
        Reload = 10;
        WeaponLocation = "Models/Guns/PREF_Persuader";
        Weapon = GunType.Persuader;
        Damage = 50;
    }

    public override void PickUp(SCR_Character ch)
    {
        Character = ch;
        Character.ActiveWeapon = this;
        Character.ATTStats = ATTStatsIncrease;
    }
}