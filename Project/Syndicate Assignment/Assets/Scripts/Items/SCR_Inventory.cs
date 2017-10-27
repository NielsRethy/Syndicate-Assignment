using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Inventory
{
    // ================================== 
    // Inventory class: 
    // ================================== 
    //  - Inventory list
    //  - Add/Remove in the list
    // ----------------------------------

    private List<SCR_Item> _itemList = new List<SCR_Item>();        //Item list
    private const int _maxItems = 12; //max items in the list

    public List<SCR_Item> ItemList
    {
        get { return _itemList; }
    }

    public bool AddItemToList(SCR_Item item)
    {
        //adding items to the inventory list
        if (ItemList.Count < _maxItems)
        {
            ItemList.Add(item);
            return true;
        }
        return false;
    }
    public void RemoveItemToList(SCR_Item item)
    {

        //Removing items fron the inventory list
        ItemList.Remove(item);
    }
}
