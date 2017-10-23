using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_EnemyManager
{

    public List<SCR_Enemy> EnemyList = new List<SCR_Enemy>();
    private int _enemyCount;
    public SCR_EnemyManager()
    {
        //spawning enemies, the amounts depence on how many spawn location there are. More spawnloaction = more enemies
        _enemyCount = GameObject.FindWithTag("StartlocationEnemy").transform.GetComponentsInChildren<Transform>().Length - 1;
        for (int i = 0; i < _enemyCount; i++)
        {
            EnemyList.Add(new SCR_Enemy(i + 1));
        }
    }

    
}
