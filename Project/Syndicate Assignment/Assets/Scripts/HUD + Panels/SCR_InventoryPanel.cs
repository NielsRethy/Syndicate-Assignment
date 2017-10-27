using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_InventoryPanel : SCR_SyndicatePanel{

    // ================================== 
    // Inventory Panel class: 
    // ================================== 
    //  - Holds the information of the inventory
    //  - Shows/hide the inventory
    // ----------------------------------

    private bool _isActive ;                                    //Switch to turn the inventory of/on                     
    public List<RawImage> IconList = new List<RawImage>();      //List of inventory item icons (to replace when an item is picked up)
    private SCR_Inventory _inventoryList;                       //Inventory list with al the items in it
    private GameObject _inventoryUI;                            //UI gameobject that is spawned when the game starts

    public override void Initialize()
    {
        //Getting inventory image holders to change when somthing is picktup
        _inventoryUI = gameObject.GetComponentInChildren<Image>().gameObject;
        _inventoryList = GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().Inventory;
        for (int i = 0; i < GetComponentsInChildren<RawImage>().Length; i++)
        {
            IconList.Add(GetComponentsInChildren<RawImage>()[i]);
        }
        //Starting with no inventory visible
        _inventoryUI.SetActive(false);
        _isActive = _inventoryUI.activeSelf;
        Name = "Inventory";
    }

    public override void Refresh()
    {
        //showing inventory
        ShowInventoryIcons();
        _isActive = !_isActive;
        _inventoryUI.SetActive(_isActive);
        SCR_GameManager.PAUSE_GAME = _isActive;
    }

    void ShowInventoryIcons()
    {
        //updating inventory icons only when inventory is open
        if (_inventoryList.ItemList.Count <= IconList.Count)
        {
            for (int i = 0; i < _inventoryList.ItemList.Count; i++)
            {
                IconList[i].texture = Resources.Load<Texture>(_inventoryList.ItemList[i].FileIconLocation);
            }
        }
    }
}
