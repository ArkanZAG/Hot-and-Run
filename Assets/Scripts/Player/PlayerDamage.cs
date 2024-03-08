using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Burning burning;

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
        var enemyBurning = other.GetComponent<Burning>();

        if (enemy == null) return;
        if (enemyBurning == null) return;
        bool isBurning = burning.IsBurning;
        if (enemyBurning.IsBurning == true) return;
        if (isBurning == true)
        {
            enemy.Burning();
        }
    }


}
