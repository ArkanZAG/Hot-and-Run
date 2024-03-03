using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;
    public void Burn()
    {
        enemyHealth.RemoveHealth(5);
        Debug.Log("Enemy is Burning");
    }

    public void Death()
    {
        
    }
}
