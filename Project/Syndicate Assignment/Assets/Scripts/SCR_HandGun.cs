using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class SCR_HandGun : SCR_Weapon
{

    public SCR_HandGun()
    {
        ATTStatsIncrease = 10;
        RateOfFire = 1;
        Reload = 10;
        WeaponLocation = "Models/Guns/PREF_HandGun";
        Weapon = GunType.Gun;
    }

    public override void PickUp(SCR_Character ch)
    {
        Character = ch;
        Character.ActiveWeapon = this;
        Character.ATTStats = ATTStatsIncrease;
    }

}
