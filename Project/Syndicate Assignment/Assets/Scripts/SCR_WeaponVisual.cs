using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SCR_WeaponVisual : MonoBehaviour {

	// Use this for initialization
    public string FileLocation;

    public SCR_Weapon Weapon;

    private GameObject _gunMesh;
	void Start () {

	    _gunMesh = Instantiate(Resources.Load(FileLocation)) as GameObject;

	    if (_gunMesh != null)
	    {
	        _gunMesh.transform.SetParent(this.transform);
	        _gunMesh.transform.localPosition = new Vector3(-0.5f, 0.3f, 0.1f);
	        _gunMesh.transform.localRotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
	    }
	}
	
	// Update is called once per frame
	void Update () {


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
