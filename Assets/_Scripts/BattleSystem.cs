using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;

    void Start()
    {
        StartBattle();    
    }

    private void StartBattle()
    {
        Debug.Log("StartBattle");
        //enemyTransform.GetComponent<EnemySpawn>().Spawn();
    }
}