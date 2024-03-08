using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;
    [SerializeField] private Burning burning;
    private Health playerHealth;
    private bool isAlive = true;

    public bool IsAlive => isAlive;

    private void Start()
    {
        enemyHealth.onDeath.AddListener(OnDead);
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

    public void Burning()
    {
        burning.Burned();
    }

    public void Initialize(Health playerHealthComponent)
    {
        playerHealth = playerHealthComponent;
    }
}
