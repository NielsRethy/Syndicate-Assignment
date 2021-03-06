﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_MoveCharacter : MonoBehaviour {

    // ================================== 
    // Move class of the character: 
    // ================================== 
    //  - Picking new location to walk to
    //  - Moving character to new location
    //  - switiching between walking in group or walking solo
    // ----------------------------------

    private GameObject _walkingPoints;      //Walking points that the not selected characters walks to
    public bool IsGroup = true;             //Checking if the player walks in group or solo

    void Start()
    {
        //Walking the nav agent
        _walkingPoints = GameObject.FindWithTag("Startlocation");
        GetComponent<NavMeshAgent>().destination =
            GameObject.FindWithTag("Startlocation").transform.GetComponentsInChildren<Transform>()[
                    GetComponent<SCR_VisualCharacter>().Character.Id]
                .position;
    }

    void Update()
    {
        PickNewWalkingLocation();
        if (Input.GetKeyDown(KeyCode.G))
        {
            //Going solo or stay with a group
            IsGroup = !IsGroup;
        }
    }

    private void PickNewWalkingLocation()
    {

        //Pick a location where the players walk to
        //Other players follow and regroup when on location
        if (!SCR_GameManager.PAUSE_GAME)
        {
            if (GetComponent<SCR_VisualCharacter>().IsSelected)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                    {
                        if (hit.transform.tag == "Ground")
                        {
                            GetComponent<NavMeshAgent>().destination = hit.point;
                        }

                    }
                }
            }
            else if (!GetComponent<SCR_VisualCharacter>().IsSelected && IsGroup)
            {
                GetComponent<NavMeshAgent>().destination =
                    _walkingPoints.transform.GetComponentsInChildren<Transform>()[
                        GetComponent<SCR_VisualCharacter>().Character.Id].position;
            }

        }
        else
        {
            GetComponent<NavMeshAgent>().destination = gameObject.transform.position;
        }
    }

   


}
