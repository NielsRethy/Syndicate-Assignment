using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SCR_Item {

    // ================================== 
    // Item class: 
    // ================================== 
    //  - UpdateList
    //  - PickUp (virtual)
    // ----------------------------------

    public enum ItemType                    //Only 2 items at this moment
    {
        Weapon = 1,
        Medkit = 2
    }
                
    public ItemType PickupObject;           //Object type
    public string FileIconLocation;         //File location for the icon (for inventory) 

    public void UpdateList(bool add)
    {
        //adding item to the list
        if (add)
        {
            GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().Inventory.AddItemToList(this);
        }
        else
        {
            GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().Inventory.RemoveItemToList(this);
        }
        
    }

    public virtual void PickUp(SCR_Character ch){}
}
