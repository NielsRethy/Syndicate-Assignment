using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CharacterManager
{

    private readonly List<SCR_Character> _charactersList = new List<SCR_Character>();
    private SCR_Character _selectedCharacter;
    private int _maxCharacters = 4;
    private float _distanceCamera = 25;
    private GameObject _walkingPoints;


    public void Initialize()
    {
        SettingWalkingPoints();
        //First character is always the first selected
        if (_charactersList.Count < 4)
        {
            for (int i = 0; i < _maxCharacters; i++)
            {
                _charactersList.Add(new SCR_Character("Player" + (i + 1).ToString(), i + 1));
            }
        }
        _selectedCharacter = _charactersList[0];
        foreach (var character in _charactersList)
        {
            character.Initialize(character == _selectedCharacter);
        }
        _walkingPoints.transform.parent = _selectedCharacter.VisualCharacter.gameObject.transform;
    }

    public void ChangeSelectedCharacter()
    {
        //Change player when clickt on
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform.gameObject.GetComponent<SCR_VisualCharacter>() != null)
            {
                SCR_VisualCharacter vc = hit.transform.gameObject.GetComponent<SCR_VisualCharacter>();
                _selectedCharacter.IsSelected = false;
                _selectedCharacter = _charactersList[vc.Character.Id - 1];
                vc.IsSelected = true;
                //GameObject.FindWithTag("Startlocation").transform.localPosition =
                // _walkingPoints.transform.GetComponentsInChildren<Transform>()[vc.Character.Id].localPosition;
               

                _walkingPoints.transform.parent = vc.gameObject.transform;
                
                //Reseting postions when the walkingpoints get a new parent object
                _walkingPoints.transform.localPosition = _walkingPoints.transform.GetComponentsInChildren<Transform>()[vc.Character.Id].localPosition * -1;
                _walkingPoints.transform.localRotation = new Quaternion(0.0f,0.0f,0.0f,0.0f);

            }
        }

    }

    public void CameraFollowSelectedCharacter()
    {
        Camera.main.transform.position = new Vector3(_selectedCharacter.VisualCharacter.transform.position.x,
            Camera.main.transform.position.y,
            _selectedCharacter.VisualCharacter.transform.position.z - _distanceCamera);
    }

    private void SettingWalkingPoints()
    {

        //Changing start position, they start in a square formation 
        //  (P1) (P2)
        //  (P3) (P4)

        _walkingPoints = GameObject.FindWithTag("Startlocation");
        GameObject point1 = new GameObject();
        GameObject point2 = new GameObject();
        GameObject point3 = new GameObject();
        GameObject point4 = new GameObject();

        point1.transform.position = new Vector3(_walkingPoints.transform.position.x - 1, _walkingPoints.transform.position.y, _walkingPoints.transform.position.z - 1);
        point2.transform.position = new Vector3(_walkingPoints.transform.position.x - 1, _walkingPoints.transform.position.y, _walkingPoints.transform.position.z + 1);
        point3.transform.position = new Vector3(_walkingPoints.transform.position.x + 1, _walkingPoints.transform.position.y, _walkingPoints.transform.position.z - 1);
        point4.transform.position = new Vector3(_walkingPoints.transform.position.x + 1, _walkingPoints.transform.position.y, _walkingPoints.transform.position.z + 1);

        point1.transform.SetParent(_walkingPoints.transform);
        point2.transform.SetParent(_walkingPoints.transform);
        point3.transform.SetParent(_walkingPoints.transform);
        point4.transform.SetParent(_walkingPoints.transform);
    }
}
