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
    //private int _amount;        

    public SCR_Item()
    {
        
    }

    public virtual void PickUp(SCR_Character ch)
    {
       
    }
}
