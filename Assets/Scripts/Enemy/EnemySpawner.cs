using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabs;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        foreach (var point in spawnPoints)
        {
            GameObject copy = Instantiate(enemyPrefabs, point.position, point.rotation);
            Enemy enemy = copy.GetComponent<Enemy>();
        }
    }
}
