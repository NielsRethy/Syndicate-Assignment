using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Enemy{

    // ================================== 
    // Enemy class: 
    // ================================== 
    //  - Holds the information of the enemy
    //  - Creating enemy mesh (in GameManager)
    // ----------------------------------

    public int Health = 100;                //Health of the enemy
    public SCR_VisualEnemy VisualEnemy;     //The visual class of this enemy

    public SCR_Enemy(int id)
    {
        //spawn enemys
        GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().CreateEnemy(id, ref VisualEnemy, this);
        Health = 100;
    }
}
