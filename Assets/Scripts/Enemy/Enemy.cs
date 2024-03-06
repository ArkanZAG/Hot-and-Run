using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;
    [SerializeField] private Burning burning;
    private Health playerHealth;

    private void Start()
    {
        enemyHealth.onDeath.AddListener(OnDead);
    }

    private void OnDead()
    {
        playerHealth.AddHealth(20);
        Destroy(gameObject);
    }

    public void Burning()
    {
        burning.Burned();
    }

    public void Initialize(Health playerHealthComponent)
    {
        playerHealth = playerHealthComponent;
    }
}
