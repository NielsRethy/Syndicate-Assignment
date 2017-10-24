﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_VisualCharacter : MonoBehaviour
{

    public SCR_Character Character;

    private GameObject _text;
    private bool _isSelected = false;
 

    public bool IsSelected
    {
        get { return _isSelected; }
        set
        {
            if (_text != null)
            {
                //Making selected player text mesh yellow to see who is selected
                _text.GetComponent<TextMesh>().color = value ? Color.yellow : Color.red;

            }
            _isSelected = value;
        }
    }


    void Start()
    {
        //adding components to character
        AddTextMesh();
        gameObject.AddComponent<NavMeshAgent>();
        gameObject.AddComponent<SCR_MoveCharacter>();

        Character.WeaponList.Add(new SCR_HandGun());
        Character.WeaponList.Add(new SCR_Persuader());

        SetWeaponActive(Character.WeaponList[0]);

    }

    void Update()
    {
        TextFacingCamera();
    }

    private void TextFacingCamera()
    {
        //text always face camera
        var pos = Camera.main.transform.position - _text.transform.position;
        pos.x = 0.0f;
        pos.z = 0.0f;
        _text.transform.LookAt(Camera.main.transform.position - pos);
        // Rotate 180 degree to face camere on the correct angle
        _text.transform.Rotate(0, 180, 0);
    }

    private void AddTextMesh()
    {

        //Adding text above player with id number
        _text = new GameObject();
        _text.AddComponent<TextMesh>();
        _text.GetComponent<TextMesh>().text = (Character.Id).ToString();
        _text.GetComponent<TextMesh>().color = _isSelected ? Color.yellow : Color.red;
        _text.transform.position = transform.position;
        _text.transform.position = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
        // Rotate 180 degree to face camere on the correct angle
        _text.transform.Rotate(0, 180, 0);
        _text.transform.parent = gameObject.transform;
    }
    public void SetWeaponActive(SCR_Weapon gun)
    {
        //adding weapon to the character
        gameObject.AddComponent<SCR_WeaponVisual>();
        gameObject.GetComponent<SCR_WeaponVisual>().FileLocation = gun.WeaponFileLocation;
        gameObject.GetComponent<SCR_WeaponVisual>().Weapon = gun;
       
    }

}



