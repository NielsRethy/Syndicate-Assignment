using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SCR_GameManager : MonoBehaviour{

    // ================================== 
    // Game manager class: 
    // ================================== 
    //  - Game manager
    //  - Making other managers
    //  - Creating Player
    //  - Creating Enemy
    //  - Creating Gun
    //  - Changing cursor
    // ----------------------------------

    public SCR_CharacterManager CharacterManager;     //Character manager
    private SCR_EnemyManager _enemyManager;             //Enemy manager
    private SCR_UIManager _uiManager;                   //UI manager
    public SCR_Inventory Inventory;                     //Inventory

    public static bool PAUSE_GAME = false;              //Paus game

    void Start () {

        //making managers 
	    CharacterManager = new SCR_CharacterManager();
        _enemyManager = new SCR_EnemyManager();
        _uiManager = new SCR_UIManager();
        Inventory = new SCR_Inventory();

        foreach (var panel in _uiManager.Panels)
        {
            panel.Initialize();
        }
    }


    void Update () {

        //when the right mouse button is pressed change the selected character
	    if (Input.GetMouseButton(1))
	    {
	        CharacterManager.ChangeSelectedCharacter();
        }

        //Updating camera
	    CharacterManager.CameraFollowSelectedCharacter();

        //Changing cursor
        ChangeCursor();


        //opening inventory when I is pressed (also pause game)
        if (Input.GetKeyDown(KeyCode.I))
        {
            foreach (var panel in _uiManager.Panels)
            {
                if (panel.Name == "Inventory")
                {
                    panel.Refresh();
                }
            }
        }
    }

    private void ChangeCursor()
    {
        //If the mouse goes over the enemy the cursor change to a hitmarker
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            if (hit.transform.tag == "Enemy")
                Cursor.SetCursor(Resources.Load<Texture2D>("Textures/Hit"), new Vector2(200, 200), CursorMode.Auto);
            else
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void CreatePlayer(int id, ref SCR_VisualCharacter vc, SCR_Character character)
    {
        // Spawn player (no prefab)
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
        //creating enemy (prefab) + adding some extra components
        GameObject enemyObject = Instantiate(Resources.Load("Models/Characters/PREF_Enemy")) as GameObject;
        if (enemyObject != null)
        {
            enemyObject.transform.position = GameObject.FindWithTag("StartlocationEnemy").transform.GetComponentsInChildren<Transform>()[id].position;
            ve = enemyObject.AddComponent<SCR_VisualEnemy>();
            ve.Enemy = enemy;
            ve.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
            ve.gameObject.tag = "Enemy";
        }
  
    }

    public void CreateGun(ref GameObject weaponMesh, SCR_Weapon weapon, GameObject location)
    {
        //creating gun set the position right
        weaponMesh = Instantiate(Resources.Load(weapon.WeaponFileLocation)) as GameObject;
        if (weaponMesh != null)
        {
            weaponMesh.transform.SetParent(location.transform);
            weaponMesh.transform.localPosition = new Vector3(-0.5f, 0.3f, 0.1f);
            weaponMesh.transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
    }
}
