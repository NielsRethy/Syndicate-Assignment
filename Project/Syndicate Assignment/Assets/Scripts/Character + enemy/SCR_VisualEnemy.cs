using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_VisualEnemy : MonoBehaviour {

    // Use this for initialization
    public SCR_Enemy Enemy;
    private GameObject _player;
    public bool CanAttack = false;
    private bool _underAttack = false;

    void Update()
    {
        if (CanAttack)
        {
            if (_player != null)
            {
                GetComponent<SCR_EnemyAttack>().AttackPlayer(_player);
            }
            
        }
    }

    public void Hit(int damage, GameObject player)
    {
        CanAttack = true;
        _player = player;
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
