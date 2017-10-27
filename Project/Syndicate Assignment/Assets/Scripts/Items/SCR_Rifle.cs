using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Rifle : SCR_Weapon
{
    // ================================== 
    // Rifle weapon class: 
    // ================================== 
    //  - Information about this weapon
    //  - Picking up weapon
    // ----------------------------------

    public SCR_Rifle()
    {
        //initialize rifle
        ATTStatsIncrease = 10;
        WeaponFileLocation = "Models/Guns/PREF_Rifle";
        FileIconLocation = "Textures/Rifle";
        Weapon = GunType.Rifle;
        Damage = 100;
        Bullets = 0;
        MaxBullets = 2;
        PickupObject = ItemType.Weapon;
    }

    public override void PickUp(SCR_Character ch)
    {
        //picking up this weapon
        Character = ch;
        Character.ATTStats = ATTStatsIncrease;
    }
}
