using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SCR_Weapon : SCR_Item{

    // ================================== 
    // Weapon class: 
    // ================================== 
    //  - Weapon information
    //  - Gun types
    //  - Adding bullets
    // ----------------------------------

    public int Bullets;                     //Bullet count of the weapon
    public int MaxBullets;                  //Max bullets the weapon can have    
    public int ATTStatsIncrease = 10;       //Increasing ATT for the character
    public SCR_Character Character;         //Character that holds the gun
    public string WeaponFileLocation;       //Weapon mesh location
    public int Damage;                      //Damage the weapon deals
    public GunType Weapon;                  //Weepon type
    public enum GunType                     //Gun types 
    {
        Gun,
        Rifle,
        Persuader
    }                   
    public override void PickUp(SCR_Character ch){}

    public void AddBullets(int bullets)
    {
        //adding bullets (only if you haven't got the max)
        Bullets += bullets;
        if (Bullets > MaxBullets)
        {
            Bullets = MaxBullets;
        }
    }

}
