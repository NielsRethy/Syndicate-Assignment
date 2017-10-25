using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_UIManager
{
    //need some work
    public GameObject InventoryPanel = new GameObject();
    public SCR_UIManager()
    {
        //making inventory
        InventoryPanel = GameObject.Instantiate(Resources.Load("Models/Panels/PREF_Inventory")) as GameObject;

    }
}
