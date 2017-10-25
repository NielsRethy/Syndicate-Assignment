using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_GameManager : MonoBehaviour
{
    private SCR_CharacterManager _characterManager;
    private SCR_EnemyManager _enemyManager;
    private SCR_UIManager _uiManager;
    public SCR_Inventory Inventory;

    public static bool PAUSE_GAME = false;

    void Start () {

	    _characterManager = new SCR_CharacterManager();
        _enemyManager = new SCR_EnemyManager();
        _uiManager = new SCR_UIManager();
        Inventory = new SCR_Inventory();;

        

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

    public void CreatePlayer(int id, ref SCR_VisualCharacter vc, SCR_Character character)
    {
        // Spawn player 
        GameObject capsuleObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        capsuleObject.tag = "Character";
        capsuleObject.transform.position = GameObject.FindWithTag("Startlocation").transform.GetComponentsInChildren<Transform>()[id].position;
        vc = capsuleObject.AddComponent<SCR_VisualCharacter>();
        vc.Character = character;

        vc.gameObject.AddComponent<NavMeshAgent>();
        vc.gameObject.AddComponent<SCR_MoveCharacter>();
    }

    public void CreateEnemy(int id,ref SCR_VisualEnemy ve, SCR_Enemy enemy)
    {

        GameObject boxObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        boxObject.transform.position = GameObject.FindWithTag("StartlocationEnemy").transform.GetComponentsInChildren<Transform>()[id].position;
        ve = boxObject.AddComponent<SCR_VisualEnemy>(); ;
        ve.Enemy = enemy;
        //adding components to enemy
        ve.gameObject.AddComponent<BoxCollider>();
        ve.gameObject.AddComponent<Rigidbody>();
        ve.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        ve.gameObject.tag = "Enemy";
    }

    public void CreateGun(ref GameObject weaponMesh, SCR_Weapon weapon, GameObject location)
    {
        weaponMesh = Instantiate(Resources.Load(weapon.WeaponFileLocation)) as GameObject;
        if (weaponMesh != null)
        {
            weaponMesh.transform.SetParent(location.transform);
            weaponMesh.transform.localPosition = new Vector3(-0.5f, 0.3f, 0.1f);
            weaponMesh.transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
    }
}
