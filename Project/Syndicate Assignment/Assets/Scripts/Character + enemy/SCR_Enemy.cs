using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Enemy
{

    private int _health;
    private int _id;
    public SCR_VisualEnemy VisualEnemy;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public SCR_Enemy(int id)
    {
        //spawn enemys
        GameObject.FindWithTag("GameManager").GetComponent<SCR_GameManager>().CreateEnemy(id, ref VisualEnemy, this);
        _id = id;
        Health = 100;
    }
}
