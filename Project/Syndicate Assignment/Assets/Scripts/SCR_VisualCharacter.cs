using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_VisualCharacter : MonoBehaviour {

	// Use this for initialization
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
        gameObject.AddComponent<NavMeshAgent>();

        //Adding text above player with id number
        _text = new GameObject();
        _text.AddComponent<TextMesh>();
        _text.GetComponent<TextMesh>().text = (Character.Id).ToString();
        _text.GetComponent<TextMesh>().color = Color.red;
        _text.transform.position = transform.position;
        _text.transform.position = new Vector3(transform.position.x, transform.position.y+2.5f, transform.position.z);
        // Rotate 180 degree to face camere on the correct angle
        _text.transform.Rotate(0,180,0);
        _text.transform.parent = gameObject.transform;



    }

    void Update()
    {
        PickNewWalkingLocation();
        TextFacingCamera();
        
    }

    private void TextFacingCamera()
    {
        var pos = Camera.main.transform.position - _text.transform.position;
        pos.x = 0.0f;
        pos.z = 0.0f;
        _text.transform.LookAt(Camera.main.transform.position - pos);
        // Rotate 180 degree to face camere on the correct angle
        _text.transform.Rotate(0, 180, 0);
    }

    private void PickNewWalkingLocation()
    {
        //Pick a location where the players walk to
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                GetComponent<NavMeshAgent>().destination = hit.point;
            }
        }
    }

  
}
