using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_GameManager : MonoBehaviour
{
    private SCR_CharacterManager _characterManager;
    private SCR_EnemyManager _enemyManager;

    void Start () {

	    _characterManager = new SCR_CharacterManager();
        _enemyManager = new SCR_EnemyManager();
    }

	
	void Update () {
	    if (Input.GetMouseButton(0))
	    {
	        _characterManager.ChangeSelectedCharacter();
        }
	    _characterManager.CameraFollowSelectedCharacter();
	    ChangeCursor();
	}

    private void ChangeCursor()
    {
        
        //If the mouse goes over the enemy the cursur change to a hitmark

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if (hit.transform.tag == "Enemy")
            {
                Cursor.SetCursor(Resources.Load<Texture2D>("Textures/Hit"), new Vector2(200, 200), CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            }
        }
        

    }
}
