using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabs;
    [SerializeField] private float yPosition;
    [SerializeField] private float minimumValue, maximumValue;
    [SerializeField] private int maximumEnemySpawned;
    [SerializeField] private Health playerHealth;
    
    private int currentEnemySpawned;

    public UnityEvent<Enemy, Health> onEnemySpawned;

    private void Spawn()
    {
        if (currentEnemySpawned >= maximumEnemySpawned) return;
        var xPosition = Random.Range(minimumValue, maximumValue);
        var zPosition = Random.Range(minimumValue, maximumValue);
        Vector3 randomPosition = new(xPosition, yPosition ,zPosition);
        var enemyCopy = Instantiate(enemyPrefabs, randomPosition, Quaternion.identity);
        var enemyHealth = enemyCopy.GetComponent<Health>();
        var enemyComponent = enemyCopy.GetComponent<Enemy>();
        onEnemySpawned.Invoke(enemyComponent, enemyHealth);
        enemyComponent.Initialize(playerHealth);
        enemyHealth.onDeath.AddListener(OnDead);
        currentEnemySpawned += 1;
    }

    private void OnDead()
    {
        currentEnemySpawned -= 1;
    }

    private void Update()
    {
        Spawn();
    }
}
