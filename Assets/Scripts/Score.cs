using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Score : MonoBehaviour
{
    [SerializeField] private int scorePoint;
    [SerializeField] private EnemySpawner enemySpawner;
    
    private int currentScore;
    
    public UnityEvent<int> onScoreChange;

    private void Awake()
    {
        enemySpawner.onEnemySpawned.AddListener(OnEnemySpawned);
    }

    private void OnEnemySpawned(Enemy enemyComponent, Health enemyHealth)
    {
        enemyHealth.onDeath.AddListener(OnEnemyDeath);
    }

    private void OnEnemyDeath()
    {
        AddScore();
        onScoreChange.Invoke(currentScore);
        Debug.Log(currentScore);
    }

    public void AddScore()
    {
        currentScore += scorePoint;
    }
}
