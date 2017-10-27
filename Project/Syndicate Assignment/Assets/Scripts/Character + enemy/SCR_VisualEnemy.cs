using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_VisualEnemy : MonoBehaviour {

    // ================================== 
    // Visual class of the enemy: 
    // ================================== 
    //  - Checking when enemy is hit.
    //  - Attack player
    //  - Changin color when hit
    // ----------------------------------

    public SCR_Enemy Enemy;                 //Enemy class that holds the info 
    private GameObject _player;             //Selected player class, needed for attack
    public bool CanAttack;                  //Bool to see if the player can attack

    void Update()
    {
        //If the enemy is under attack, attack the player
        if (CanAttack)
        {
            if (_player != null)
            {
                if (!_player.GetComponent<SCR_VisualCharacter>().IsSelected)
                {
                    //group attacks? attack the selected character
                    GetComponent<SCR_EnemyAttack>().AttackPlayer(GameObject.FindWithTag("GameManager")
                        .GetComponent<SCR_GameManager>().CharacterManager.SelectedCharacter.VisualCharacter.gameObject);
                }
                else
                {
                    GetComponent<SCR_EnemyAttack>().AttackPlayer(_player);
                }
            }
            
        }
    }

    public void Hit(int damage, GameObject player)
    {
        //If the enemy is hit , take damage and attack the player!
        CanAttack = true;
        _player = player;
        StartCoroutine(ChangeColorWhenHit());
        
        if (Enemy.Health <= 0.0f)
            Destroy(gameObject);
        else
            Enemy.Health -= damage;
    }

    IEnumerator ChangeColorWhenHit()
    {
        //change color of the enemy when hit (so you know you shot a bullet) 
        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(.1f);
        GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(.1f);
    }
}

