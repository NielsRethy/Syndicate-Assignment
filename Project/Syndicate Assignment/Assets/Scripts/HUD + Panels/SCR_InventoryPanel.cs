using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_InventoryPanel : SCR_SyndicatePanel
{

	// Use this for initialization
    private bool isActive = false;
    List<RawImage> IconList = new List<RawImage>();
    private SCR_Inventory _inventoryList;

    private GameObject _inventoryUI;
	void Start ()
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
	    isActive = _inventoryUI.activeSelf;
    }
	
	// Update is called once per frame
	void Update () {

        //opening inventory when I is pressed (also pause game)
	    if (Input.GetKeyDown(KeyCode.I))
	    {
	        ShowInventoryIcons();

            isActive = !isActive;
            _inventoryUI.SetActive(isActive);
	        SCR_GameManager.PAUSE_GAME = isActive;
            
	    }
	}

    void ShowInventoryIcons()
    {
        //updating inventory icons only when inventory is open
        if (_inventoryList.ItemList.Count < IconList.Count)
        {
            for (int i = 0; i < _inventoryList.ItemList.Count; i++)
            {
                IconList[i].texture = Resources.Load<Texture>(_inventoryList.ItemList[i].FileIconLocation);
            }
        }
    }
}
