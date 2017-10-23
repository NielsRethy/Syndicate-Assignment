using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SCR_WeaponVisual : MonoBehaviour
{

    // Use this for initialization
    public string FileLocation;

    public SCR_Weapon Weapon;

    private GameObject _gunMesh;

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
    }

    void Update()
    {
        ChangeGun();
        ShootOnEnemy();
    }

    private void ShootOnEnemy()
    {
        //shooting on enemy if mouse is on the target
        if (Input.GetMouseButtonDown(0))
        {
            if (GetComponent<SCR_VisualCharacter>().IsSelected)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.GetComponent<SCR_VisualEnemy>().Hit(Weapon.Damage);
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

                switch (Weapon.Weapon)
                {
                    case SCR_Weapon.GunType.Persuader:
                        Weapon = new SCR_HandGun();
                        break;
                    case SCR_Weapon.GunType.Gun:
                        Weapon = new SCR_Rifle();
                        break;
                    case SCR_Weapon.GunType.Rifle:
                        Weapon = new SCR_Persuader();
                        break;
                }
                Destroy(_gunMesh);
                _gunMesh = Instantiate(Resources.Load(Weapon.WeaponLocation)) as GameObject;
                _gunMesh.transform.SetParent(this.transform);
                _gunMesh.transform.localPosition = new Vector3(-0.5f, 0.3f, 0.1f);
                _gunMesh.transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);

            }
        }
    }

}
 




