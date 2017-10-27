using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Character {

	// Use this for initialization

    private string _name;
    public int Health = 100;
    public int ATTStats;
    private SCR_Weapon _activeWeapon;
    public List<SCR_Weapon> WeaponList = new List<SCR_Weapon>();

    private bool _isSelected;
    private int _id;

    public SCR_Character(string name, int id)
    {
        _name = name;
        _id = id;

        // Spawn player 
        GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().CreatePlayer(_id, ref VisualCharacter,this);

    }

    public void AddWeaponToList(SCR_Weapon w)
    {
        w.UpdateList(true);
        WeaponList.Add(w);
    }
    public void RemoveWeaponFromList(SCR_Weapon w)
    {
        w.UpdateList(false);
        WeaponList.Remove(w);
    }
    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            _isSelected = value;
            VisualCharacter.IsSelected = value;
        }
    }


    public SCR_VisualCharacter VisualCharacter;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public SCR_Weapon ActiveWeapon
    {
        get { return _activeWeapon; }
        set
        {
            _activeWeapon = value;
        }
    }


   

}
