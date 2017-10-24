using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Persuader : SCR_Weapon
{
    //Persuader gun class
    public SCR_Persuader()
    {
        ATTStatsIncrease = 10;
        WeaponFileLocation = "Models/Guns/PREF_Persuader";
        WeaponFileIconLocation = "Textures/Persuader";
        Weapon = GunType.Persuader;
        Damage = 50;
        Bullets = 0;
        MaxBullets = 8;
    }

    public override void PickUp(SCR_Character ch)
    {
        Character = ch;
        Character.ActiveWeapon = this;
        Character.ATTStats = ATTStatsIncrease;
    }
}