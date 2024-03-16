using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health enemyHealth;
    private IBurnable burning;
    private Health playerHealth;
    private IBurnable playerBurning;
    private bool isAlive = true;

    public bool IsAlive => isAlive;

    private void Start()
    {
        enemyHealth.onDeath.AddListener(OnDead);
        burning = gameObject.GetComponent<IBurnable>();
    }

    private void OnDead()
    {
        playerHealth.AddHealth(20);
        transform.DOScale(new Vector3(1.5f, 1.5f, 0f), 0.5f).OnComplete(OnSizeUpComplete);
        isAlive = false;
    }

    private void OnSizeUpComplete()
    {
        transform.DOScale(new Vector3(1f, 1f, 0f), 0.5f).OnComplete(OnSizeDownComplete);
    }

    private void OnSizeDownComplete()
    {
        Destroy(gameObject);
    }

    public void Initialize(Health playerHealthComponent, IBurnable playerBurn)
    {
        playerHealth = playerHealthComponent;
        playerBurning = playerBurn;
    }

    public void OnDamage()
    {
        if (playerBurning.IsBurning)
        {
            burning.StartBurn();
        }
    }
}
