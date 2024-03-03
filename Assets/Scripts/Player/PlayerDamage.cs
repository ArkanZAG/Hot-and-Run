using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();

        if (enemy == null) return;

        enemy.Burn();
        playerHealth.AddHealth(20);
        
        Debug.Log("Player is entering enemy collider");
    }
    
    
}
