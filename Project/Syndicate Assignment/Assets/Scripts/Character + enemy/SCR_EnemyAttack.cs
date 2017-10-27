using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyAttack : MonoBehaviour {

	// Use this for initialization
    public int damage = 5;
    public float Reach = 7;
    private bool _canAttack = true;


    public void AttackPlayer(GameObject player)
    {
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
        _canAttack = false;
        // Code to execute after the delay
        yield return new WaitForSeconds(1.0f);
        player.GetComponent<SCR_VisualCharacter>().UnderAttack(damage);
        _canAttack = true;


    }
}
