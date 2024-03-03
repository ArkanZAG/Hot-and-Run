using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;
    [SerializeField] private Burning burning;

    private void Start()
    {
        enemyHealth.onDeath.AddListener(OnDead);
    }

    private void OnDead()
    {
        Destroy(gameObject);
    }

    public void Burning()
    {
        burning.Burned();
    }
}
