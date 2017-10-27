using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Character {

    // ================================== 
    // Character class: 
    // ================================== 
    //  - Holds the information of the Character
    //  - Creating Character mesh (in GameManager)
    //  - Adding/Removing weapons
    // ----------------------------------


    public string Name;                                             //Name of this character
    public int Id;                                                  //ID of this character
    public int Health = 100;                                        //Health of this character
    public int ATTStats;                                            //ATTStats of this character
    public SCR_Weapon ActiveWeapon;                                 //Active weapon
    public List<SCR_Weapon> WeaponList = new List<SCR_Weapon>();    //List of weapons that it can use
    public SCR_VisualCharacter VisualCharacter;                     //Visual class of this character

    private bool _isSelected;                                       //Check if its the selected character
    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            _isSelected = value;
            VisualCharacter.IsSelected = value;
        }
    }

    public SCR_Character(string name, int id)
    {
        // Spawn player
        Name = name;
        Id = id; 
        GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().CreatePlayer(Id, ref VisualCharacter,this);

    }   
    public void AddWeaponToList(SCR_Weapon w)
    {
        //adding weapon to its list
        w.UpdateList(true);
        WeaponList.Add(w);
    }
    public void RemoveWeaponFromList(SCR_Weapon w)
    {
        //Removing weapon from this list
        w.UpdateList(false);
        WeaponList.Remove(w);
    }


   

}
