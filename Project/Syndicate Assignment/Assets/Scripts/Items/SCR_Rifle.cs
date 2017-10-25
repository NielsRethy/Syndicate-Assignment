using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Rifle : SCR_Weapon
{
    //Rifle gun class
    public SCR_Rifle()
    {
        ATTStatsIncrease = 10;
        WeaponFileLocation = "Models/Guns/PREF_Rifle";
        FileIconLocation = "Textures/Rifle";
        Weapon = GunType.Rifle;
        Damage = 100;
        Bullets = 0;
        MaxBullets = 2;
    }

    public override void PickUp(SCR_Character ch)
    {
        Character = ch;
        Character.ActiveWeapon = this;
        Character.ATTStats = ATTStatsIncrease;
    }
}
