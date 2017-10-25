using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SCR_Item {
    public enum ItemType
    {
        Weapon = 1,
        Health = 2,
        Ammo = 3
    }
                
    public ItemType _pickupObject;
    public string FileIconLocation;
    //private int _amount;        

    public SCR_Item()
    {
        
    }

    public void UpdateList(bool add)
    {
        if (add)
        {
            GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().Inventory.AddItemToList(this);
        }
        else
        {
            GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().Inventory.RemoveItemToList(this);
        }
        
    }

    public virtual void PickUp(SCR_Character ch)
    {
       
    }
}
