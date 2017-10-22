using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameManager : MonoBehaviour
{
    private SCR_CharacterManager _characterManager;

	// Use this for initialization
	void Start () {

	    _characterManager = new SCR_CharacterManager();
	    _characterManager.Initialize();

    }

	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0))
	    {
	        _characterManager.ChangeSelectedCharacter();
        }
	    _characterManager.CameraFollowSelectedCharacter();
    }
}
