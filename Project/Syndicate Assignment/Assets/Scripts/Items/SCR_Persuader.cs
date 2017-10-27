using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Persuader : SCR_Weapon{

    // ================================== 
    // Persuader weapon class: 
    // ================================== 
    //  - Information about this weapon
    //  - Picking up weapon
    // ----------------------------------

    public SCR_Persuader()
    {
        //initialize Persuader
        ATTStatsIncrease = 10;
        WeaponFileLocation = "Models/Guns/PREF_Persuader";
        FileIconLocation = "Textures/Persuader";
        Weapon = GunType.Persuader;
        Damage = 50;
        Bullets = 0;
        MaxBullets = 8;
        PickupObject = ItemType.Weapon;
    }

    public override void PickUp(SCR_Character ch)
    {
        //picking up this weapon
        Character = ch;
        Character.ATTStats = ATTStatsIncrease;
    }
}