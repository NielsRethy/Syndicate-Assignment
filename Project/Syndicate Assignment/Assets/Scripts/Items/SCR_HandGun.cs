using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class SCR_HandGun : SCR_Weapon
{
    //Hand gun class
    public SCR_HandGun()
    {
        ATTStatsIncrease = 10;
        WeaponFileLocation = "Models/Guns/PREF_HandGun";
        WeaponFileIconLocation = "Textures/HandGun";
        Weapon = GunType.Gun;
        Damage = 20;
        Bullets = 0;
        MaxBullets = 12;
    }

    public override void PickUp(SCR_Character ch)
    {
        Character = ch;
        Character.ActiveWeapon = this;
        Character.ATTStats = ATTStatsIncrease;
    }

}
