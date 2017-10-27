
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_CharacterManager
{
    // ================================== 
    // Character manager class: 
    // ================================== 
    //  - Character manager
    //  - Spawning characters
    //  - Changing selected character
    //  - Changing camera
    //  - Spawning walk points
    // ----------------------------------

    private readonly List<SCR_Character> _charactersList = new List<SCR_Character>();       //Character list
    public SCR_Character SelectedCharacter;                                                 //Selected character
    private int _maxCharacters = 4;                                                         //Max character count
    private float _distanceCamera = 25;                                                     //Camera distance
    private GameObject _walkingPoints;                                                      //Walking points where the not selected characters walk to regroup

    public SCR_CharacterManager()
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
        SelectedCharacter = _charactersList[0];
        SelectedCharacter.IsSelected = true;

        //Parenting the walking points to the selected player (walking points are there to have a formation)
        _walkingPoints.transform.parent = SelectedCharacter.VisualCharacter.gameObject.transform;
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
                SelectedCharacter.VisualCharacter.IsSelected = false;
                SelectedCharacter.IsSelected = false;
                foreach (var charac in _charactersList)
                {
                    if (charac == vc.Character)
                    {
                        SelectedCharacter = charac;
                    }
                }
               
                SelectedCharacter.VisualCharacter.IsSelected = true;
                SelectedCharacter.IsSelected = true;

                _walkingPoints.transform.parent = vc.gameObject.transform;
                
                //Reseting postions when the walkingpoints get a new parent object
                _walkingPoints.transform.localPosition = _walkingPoints.transform.GetComponentsInChildren<Transform>()[vc.Character.Id].localPosition * -1;
                _walkingPoints.transform.localRotation = new Quaternion(0.0f,0.0f,0.0f,0.0f);

                //update HUD
                GameObject.FindWithTag("HUD").GetComponent<SCR_HUD>().UpdateSelectedPlayer(SelectedCharacter.Id - 1);
            }
        }

    }

    public void CameraFollowSelectedCharacter()
    {
        //Camera folows selected player but doesnt rotate, always the same angle

        Camera.main.transform.position = new Vector3(SelectedCharacter.VisualCharacter.transform.position.x,
            Camera.main.transform.position.y,
            SelectedCharacter.VisualCharacter.transform.position.z - _distanceCamera);
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
    public void NewSelectedCharacter(SCR_Character chr)
    {
        _charactersList.Remove(chr);
        //Change character when player dies
        if (_charactersList.Count > 0)
        {
            
            SelectedCharacter = _charactersList[0];
            SelectedCharacter.VisualCharacter.IsSelected = true;
            _walkingPoints.transform.parent = SelectedCharacter.VisualCharacter.gameObject.transform;

            //Reseting postions when the walkingpoints get a new parent object
            _walkingPoints.transform.localPosition = _walkingPoints.transform.GetComponentsInChildren<Transform>()[SelectedCharacter.Id].localPosition * -1;
            _walkingPoints.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);

            //update HUD
            GameObject.FindWithTag("HUD").GetComponent<SCR_HUD>().UpdateSelectedPlayer(SelectedCharacter.Id - 1);
        }
        else
        {
            //no players left? Quit game
            Application.Quit();
        }
    }
}
