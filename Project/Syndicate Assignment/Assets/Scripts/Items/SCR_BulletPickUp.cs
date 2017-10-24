using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BulletPickUp : MonoBehaviour {

    // Use this for initialization
    public int Bullets = 5;

    public bool HandGunAmmo = true;
    public bool RifleAmmo = false;
    public bool PersuaderAmmo = false;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Character")
        {
            if (other.GetComponentInChildren<SCR_VisualCharacter>().IsSelected)
            {
                foreach (var w in other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList)
                {
                    if (w.Weapon == SCR_Weapon.GunType.Gun && HandGunAmmo || w.Weapon == SCR_Weapon.GunType.Rifle && RifleAmmo || w.Weapon == SCR_Weapon.GunType.Persuader && PersuaderAmmo)
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
