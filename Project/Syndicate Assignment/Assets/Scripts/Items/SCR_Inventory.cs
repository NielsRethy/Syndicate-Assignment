using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Inventory
{
    private List<SCR_Item> _itemList = new List<SCR_Item>();
    private int maxItems = 12;

    public List<SCR_Item> ItemList
    {
        get { return _itemList; }
    }

    public bool AddItemToList(SCR_Item item)
    {
        //adding items to the inventory list
        if (ItemList.Count < maxItems)
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
