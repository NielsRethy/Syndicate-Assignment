using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_MoveCharacter : MonoBehaviour {

    private GameObject _walkingPoints;
    private bool _group = true;

    void Start()
    {
        _walkingPoints = GameObject.FindWithTag("Startlocation");
        GetComponent<NavMeshAgent>().destination =
            GameObject.FindWithTag("Startlocation").transform.GetComponentsInChildren<Transform>()[
                    GetComponent<SCR_VisualCharacter>().Character.Id]
                .position;
    }

    // Update is called once per frame
    void Update()
    {
        PickNewWalkingLocation();

        if (Input.GetMouseButtonDown(1))
        {
            _group = !_group;
           // _walkingPoints.transform.localPosition = _walkingPoints.transform.GetComponentsInChildren<Transform>()[GetComponent<SCR_VisualCharacter>().Character.Id].localPosition * -1;
        }
    }

    private void PickNewWalkingLocation()
    {

        //Pick a location where the players walk to
        //Other players follow and regroup when on location

        if (GetComponent<SCR_VisualCharacter>().IsSelected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    GetComponent<NavMeshAgent>().destination = hit.point;
                }
            }
        }
        else if (!GetComponent<SCR_VisualCharacter>().IsSelected && _group)
        {
            GetComponent<NavMeshAgent>().destination =
                _walkingPoints.transform.GetComponentsInChildren<Transform>()[
                    GetComponent<SCR_VisualCharacter>().Character.Id].position;


        }

    }
}
