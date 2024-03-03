using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;

    private void Start()
    {
        enemyHealth.onDeath.AddListener(OnDead);
    }

    private void OnDead()
    {
        Destroy(gameObject);
    }

    public void Burn()
    {
        enemyHealth.RemoveHealth(Time.deltaTime);
        Debug.Log("Enemy is Burning");
    }
}
