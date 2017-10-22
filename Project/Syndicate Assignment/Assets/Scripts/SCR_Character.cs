using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Character {

	// Use this for initialization

    private string _name;
    private bool _isSelected;
    private int _id;

    public SCR_Character(string name, int id)
    {
        _name = name;
        _id = id;
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


    public SCR_VisualCharacter VisualCharacter { get; set; }

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public void Initialize(bool selected)
    {
        // Spawn player 
        GameObject capsuleObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        capsuleObject.transform.position = SwitchSpawnPosition(_id, capsuleObject);
        VisualCharacter = capsuleObject.AddComponent<SCR_VisualCharacter>();
        VisualCharacter.IsSelected = selected;
        VisualCharacter.Character = this;
        _isSelected = selected;
    }

    private Vector3 SwitchSpawnPosition(int id, GameObject character)
    {
        //Changing start position, they start in a square formation 
        //  (P1) (P2)
        //  (P3) (P4)

        Vector3 startPos = GameObject.FindWithTag("Startlocation").transform.position;
        switch (id)
        {
            case 2:
                startPos = new Vector3(startPos.x + character.GetComponent<Collider>().bounds.size.x, startPos.y, startPos.z);
                break;
            case 3:
                startPos = new Vector3(startPos.x , startPos.y, startPos.z + character.GetComponent<Collider>().bounds.size.z);
                break;
            case 4:
                startPos = new Vector3(startPos.x + character.GetComponent<Collider>().bounds.size.x, startPos.y, startPos.z + character.GetComponent<Collider>().bounds.size.z);
                break;
            default:
                startPos = GameObject.FindWithTag("Startlocation").transform.position;
                return startPos;
                break;
        }
        return startPos;
    }

}
