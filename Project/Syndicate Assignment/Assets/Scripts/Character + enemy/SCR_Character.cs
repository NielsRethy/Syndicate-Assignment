using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Character {

	// Use this for initialization

    private string _name;
    public int ATTStats;
    private SCR_Weapon _activeWeapon;

    private bool _isSelected;
    private int _id;

    public SCR_Character(string name, int id)
    {
        _name = name;
        _id = id;

         // Spawn player 
        GameObject capsuleObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsuleObject.transform.position = GameObject.FindWithTag("Startlocation").transform.GetComponentsInChildren<Transform>()[_id].position;
        VisualCharacter = capsuleObject.AddComponent<SCR_VisualCharacter>();
        VisualCharacter.Character = this;

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


    public SCR_VisualCharacter VisualCharacter { get; set ; }

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
            //VisualCharacter.AddWeapon();
        }
    }


   

}
