using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BulletPickUp : MonoBehaviour {

    // ================================== 
    // Bullet pick up class: 
    // ================================== 
    //  - Pick up bullets and adding to the correct gun
    // ----------------------------------

    public int Bullets = 5;                 //Bullets to add
    public bool IsHandGunAmmo = true;       //Checking if this object is hand gun ammo
    public bool IsRifleAmmo = false;        //Checking if this object is rifle ammo
    public bool IsPersuaderAmmo = false;    ///Checking if this object is persuader ammo

    void OnTriggerStay(Collider other)
    {
        //checking if the collider is the character
        if (other.tag == "Character")
        {
            //only selected player can pickup 
            if (other.GetComponentInChildren<SCR_VisualCharacter>().IsSelected)
            {
                foreach (var w in other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList)
                {
                    if (w.Weapon == SCR_Weapon.GunType.Gun && IsHandGunAmmo || w.Weapon == SCR_Weapon.GunType.Rifle && IsRifleAmmo || w.Weapon == SCR_Weapon.GunType.Persuader && IsPersuaderAmmo)
                    {
                        w.AddBullets(Bullets);
                        other.GetComponentInChildren<SCR_WeaponVisual>().UpdateBullets();
                        Destroy(gameObject);
                        return;
                    }

                }
               
            }
        }
     
    }
}
