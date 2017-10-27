using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyAttack : MonoBehaviour {

    // ================================== 
    // Attack class of the Enemy: 
    // ================================== 
    //  - Attack enemy
    // ----------------------------------

    public int Damage = 5;                      //The damage this enemy deals
    public float Reach = 15;                    //The distance where the enemy can hit the player (shoot)
    private bool _canAttack = true;             //Checking if the player can be attacked
    public float SecondsBetweenAttack = 1.0f;   //Seconds between each hit

    public void AttackPlayer(GameObject player)
    {
        //Checking the distance between the player and enemy. Attack if its in reach
        if (Vector3.Distance(transform.position, player.transform.position) < Reach)
        {
            gameObject.transform.LookAt(player.transform);

            if (_canAttack)
            {
                StartCoroutine(DoDamage(player));
            }
        }
    }

    
    IEnumerator DoDamage(GameObject player)
    {
        //Shooting enemy with a delay between each shot
        _canAttack = false;
        yield return new WaitForSeconds(SecondsBetweenAttack);
        player.GetComponent<SCR_VisualCharacter>().UnderAttack(Damage);
        _canAttack = true;


    }
}
