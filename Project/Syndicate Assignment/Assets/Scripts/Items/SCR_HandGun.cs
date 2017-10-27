using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class SCR_HandGun : SCR_Weapon{

    // ================================== 
    // Hand gun weapon class: 
    // ================================== 
    //  - Information about this weapon
    //  - Picking up weapon
    // ----------------------------------
    
    public SCR_HandGun()
    {
        //initialize hand gun
        ATTStatsIncrease = 10;
        WeaponFileLocation = "Models/Guns/PREF_HandGun";
        FileIconLocation = "Textures/HandGun";
        Weapon = GunType.Gun;
        Damage = 20;
        Bullets = 0;
        MaxBullets = 12;
        PickupObject = ItemType.Weapon;
    }

    public override void PickUp(SCR_Character ch)
    {
        //picking up this weapon
        Character = ch;
        Character.ATTStats = ATTStatsIncrease;
    }

}
