using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Movement playerMovement;

    private void Start()
    {
        playerHealth.onDeath.AddListener(OnDead);
    }

    private void OnDead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();

        if (enemy == null) return;

        bool isBurning = playerMovement.IsBurning;

        if (isBurning == true)
        {
            enemy.Burn();
            playerHealth.AddHealth(20);
        }
    }


}
