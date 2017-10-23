using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Enemy
{

    private int _health;
    private int _id;
    public SCR_VisualEnemy VisualEnemy { get; set; }

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

        GameObject boxObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        boxObject.transform.position = GameObject.FindWithTag("StartlocationEnemy").transform.GetComponentsInChildren<Transform>()[id].position;
        VisualEnemy = boxObject.AddComponent<SCR_VisualEnemy>();;
        VisualEnemy.Enemy = this;


        _id = id;
        Health = 100;
    }
}
