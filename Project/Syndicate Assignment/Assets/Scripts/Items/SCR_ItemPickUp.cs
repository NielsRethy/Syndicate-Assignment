using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickUp : MonoBehaviour {

    // ================================== 
    // Item pick up class: 
    // ================================== 
    //  - Picking up items 
    //      -Hand gun
    //      -Rifle
    //      -Persuader
    //      -Medkit
    // ----------------------------------

    public bool IsHandGun = true;               //Checking if this object is a hand gun
    public bool IsRifle = false;                //Checking if this object is a rifle
    public bool IsPersuader = false;            //Checking if this object is a persuader
    public bool IsMedKit = false;               //Checking if this object is a medkit
    private SCR_GameManager _gameManager;       //Game manager needed for adding to itemlist

    void Start()
    {
        //initialize game manager
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>();
    }
    void OnTriggerStay(Collider other)
    {
        //Checking if collider object is the player
        if (other.tag == "Character")
        {
            //only selected character can pick items up
            if (other.GetComponentInChildren<SCR_VisualCharacter>().IsSelected)
            {
                bool deleteWeapon = false;
                if (IsMedKit)
                {
                    //if medkit, add to inventory
                    deleteWeapon = _gameManager.Inventory.AddItemToList(new SCR_Medkit());
                    if (deleteWeapon) Destroy(gameObject);
                }
                else
                {
                    foreach (var w in other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList)
                    {
                        //if this type of weapon is already in the weapon list then i dont need to add it anymore 
                        if (w.Weapon == SCR_Weapon.GunType.Gun && IsHandGun ||
                            w.Weapon == SCR_Weapon.GunType.Rifle && IsRifle ||
                            w.Weapon == SCR_Weapon.GunType.Persuader && IsPersuader)
                        {
                            return;
                        }

                    }
                    if (IsHandGun)
                    {
                        var newHandGun = new SCR_HandGun();
                        deleteWeapon = _gameManager.Inventory.AddItemToList(newHandGun);
                        if (deleteWeapon)
                        {
                            newHandGun.PickUp(other.GetComponent<SCR_VisualCharacter>().Character);
                            other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList.Add(newHandGun);
                        }


                    }
                    else if (IsRifle)
                    {
                        var newRifle = new SCR_Rifle();
                        deleteWeapon = _gameManager.Inventory.AddItemToList(newRifle);
                        if (deleteWeapon)
                        {
                            newRifle.PickUp(other.GetComponent<SCR_VisualCharacter>().Character);
                            other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList.Add(newRifle);
                        }
                    }
                    else if (IsPersuader)
                    {
                        var newPersuader = new SCR_Persuader();
                        deleteWeapon = _gameManager.Inventory.AddItemToList(newPersuader);
                        if (deleteWeapon)
                        {
                            newPersuader.PickUp(other.GetComponent<SCR_VisualCharacter>().Character);
                            other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList.Add(newPersuader);
                        }
                    }
                    if (deleteWeapon) Destroy(gameObject);

                }

            }
        }

    }
}
