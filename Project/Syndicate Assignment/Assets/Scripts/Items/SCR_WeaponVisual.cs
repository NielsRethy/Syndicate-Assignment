using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SCR_WeaponVisual : MonoBehaviour
{
    // ================================== 
    // Weapon visual class: 
    // ================================== 
    //  - Shooting on enemy
    //  - Changing the gun
    //  - Updating bullets on the HUD
    // ----------------------------------

    public string FileLocation;             //Location of prefab file (in recource folder)
    public SCR_Weapon Weapon;               //Weapon 
    private GameObject _gunMesh;            //Mesh of the weapon
    private GameObject _hud;                //Reference to the HUD

    void Start()
    {
        // Adding gun to character
        _gunMesh = Instantiate(Resources.Load(FileLocation)) as GameObject;
        if (_gunMesh != null)
        {
            _gunMesh.transform.SetParent(this.transform);
            _gunMesh.transform.localPosition = new Vector3(-0.5f, 0.3f, 0.1f);
            _gunMesh.transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        }
        _hud = GameObject.FindWithTag("HUD");

        //starting with 10 bullets
        Weapon.AddBullets(10);
        UpdateBullets();
    }

    void Update()
    {
        ChangeGun();
        ShootOnEnemy();
    }

    private void ShootOnEnemy()
    {
        //shooting on enemy if mouse is on the target and the weapon has bullets
        if (Weapon.Bullets > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //When your in a group evry character shoots, when solo only the selected shoot
                if (GetComponent<SCR_MoveCharacter>().IsGroup || GetComponent<SCR_VisualCharacter>().IsSelected)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                    {
                        if (hit.transform.tag == "Enemy")
                        {
                            transform.LookAt(hit.transform);
                            hit.transform.GetComponent<SCR_VisualEnemy>().Hit(Weapon.Damage, gameObject);
                            Weapon.Bullets -= 1;
                            _hud.GetComponent<SCR_HUD>().AmmoUpdate(GetComponentInParent<SCR_VisualCharacter>().Character.Id - 1,Weapon.Bullets);
                        }
                    }
                }

            }
        }
    }

    private void ChangeGun()
    {
        //changing gun with mouse scroll wheel
        if (GetComponentInParent<SCR_VisualCharacter>().IsSelected)
        {
            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0 || d < 0f)
            {
                Destroy(_gunMesh);
                SwitchWeapon();
                //Spawning gun object (code in GameManager)
                GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().CreateGun(ref _gunMesh, Weapon, this.gameObject);

                //Updating HUD
                _hud.GetComponent<SCR_HUD>().AmmoUpdate(GetComponentInParent<SCR_VisualCharacter>().Character.Id - 1, Weapon.Bullets);
                _hud.GetComponent<SCR_HUD>().SetNewWeaponIcon(GetComponentInParent<SCR_VisualCharacter>().Character.Id - 1, Weapon.FileIconLocation);
            }
        }
    }

    private void SwitchWeapon()
    {
        //looking in gun list and switching if there are more weapons
        for (int i = 0; i < GetComponentInParent<SCR_VisualCharacter>().Character.WeaponList.Count; i++)
        {
            if (Weapon.Weapon == GetComponentInParent<SCR_VisualCharacter>().Character.WeaponList[i].Weapon)
            {
                if (i + 1 < GetComponentInParent<SCR_VisualCharacter>().Character.WeaponList.Count)
                {
                    Weapon = GetComponentInParent<SCR_VisualCharacter>().Character.WeaponList[i + 1];
                    return;
                }
                Weapon = GetComponentInParent<SCR_VisualCharacter>().Character.WeaponList[0];
            }
        }
    }

    public void UpdateBullets()
    {
        //Update HUD for the bullets
        _hud.GetComponent<SCR_HUD>().AmmoUpdate(GetComponentInParent<SCR_VisualCharacter>().Character.Id - 1, Weapon.Bullets);
    }


}
 




