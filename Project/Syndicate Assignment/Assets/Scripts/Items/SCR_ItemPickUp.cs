using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_ItemPickUp : MonoBehaviour {

    public bool HandGun = true;
    public bool Rifle = false;
    public bool Persuader = false;
    public bool MedKit = false;
    private SCR_GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Character")
        {
            if (other.GetComponentInChildren<SCR_VisualCharacter>().IsSelected)
            {
                bool deleteWeapon = false;
                if (MedKit)
                {
                    deleteWeapon = _gameManager.Inventory.AddItemToList(new SCR_Medkit());
                    if (deleteWeapon) Destroy(gameObject);
                }
                else
                {


                    foreach (var w in other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList)
                    {
                        if (w.Weapon == SCR_Weapon.GunType.Gun && HandGun ||
                            w.Weapon == SCR_Weapon.GunType.Rifle && Rifle ||
                            w.Weapon == SCR_Weapon.GunType.Persuader && Persuader)
                        {
                           
                            return;
                        }

                    }
                    if (HandGun)
                    {
                        var newHandGun = new SCR_HandGun();
                        deleteWeapon = _gameManager.Inventory.AddItemToList(newHandGun);
                        other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList.Add(newHandGun);
                    }
                    else if (Rifle)
                    {
                        var newRifle = new SCR_Rifle();
                        deleteWeapon = _gameManager.Inventory.AddItemToList(newRifle);
                        other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList.Add(newRifle);
                    }
                    else if (Persuader)
                    {
                        var newPersuader = new SCR_Persuader();
                        deleteWeapon = _gameManager.Inventory.AddItemToList(newPersuader);
                        other.GetComponentInChildren<SCR_VisualCharacter>().Character.WeaponList.Add(newPersuader);
                    }
                    if (deleteWeapon) Destroy(gameObject);

                }

            }
        }

    }
}
