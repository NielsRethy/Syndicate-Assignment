using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_UIManager
{
    // ================================== 
    // UI manager class: 
    // ================================== 
    //  - UI manager
    //  - Making inventory panel
    // ----------------------------------

    public List<SCR_SyndicatePanel> Panels = new List<SCR_SyndicatePanel>();     //List of active panels

    public SCR_UIManager()
    {
        //making inventory
        var inventoryPanel = GameObject.Instantiate(Resources.Load("Models/Panels/PREF_Inventory")) as GameObject;
        if (inventoryPanel != null) Panels.Add(inventoryPanel.GetComponent<SCR_InventoryPanel>());
    }
}
