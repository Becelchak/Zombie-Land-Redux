using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemyList;
    public Vector3[] spawnPoints;
    public GameObject setEnemy;
    void Start()
    {
        for (var i = 0; i <= enemyList.Length - 1; i++)
        {
            setEnemy = Instantiate(enemyList[Random.Range(0, enemyList.Length)]);
            setEnemy.transform.position = spawnPoints[i];
        }
    }

    void Update()
    {
        
    }
}
