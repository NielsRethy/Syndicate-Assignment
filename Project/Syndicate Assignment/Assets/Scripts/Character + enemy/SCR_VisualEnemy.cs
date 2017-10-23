using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_VisualEnemy : MonoBehaviour {

    // Use this for initialization
    public SCR_Enemy Enemy;
    void Start ()
	{
        //adding components to enemy
	    gameObject.AddComponent<BoxCollider>();
	    gameObject.AddComponent<Rigidbody>();
	    gameObject.GetComponent<MeshRenderer>().material.color= Color.red;
	    gameObject.tag = "Enemy";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit(int damage)
    {
        //If the enemy is hit , take damage
        if (Enemy.Health <= 0.0f)
        {
            Destroy(gameObject);
        }
        else
        {
            Enemy.Health -= damage;
        }
    }

}
