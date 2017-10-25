using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_VisualEnemy : MonoBehaviour {

    // Use this for initialization
    public SCR_Enemy Enemy;

    public void Hit(int damage)
    {
        StartCoroutine(ChangeColorWhenHit());
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
    IEnumerator ChangeColorWhenHit()
    {
            GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(.1f);
            GetComponent<Renderer>().material.color = Color.blue;
            yield return new WaitForSeconds(.1f);   
    }
}
