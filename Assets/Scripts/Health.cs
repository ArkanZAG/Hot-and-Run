using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float curenthealthValue;
    [SerializeField] private float maxHealthValue;

    public void AddHealth(float heal)
    {
        curenthealthValue += heal;
        if (curenthealthValue > maxHealthValue)
        {
            curenthealthValue = maxHealthValue;
        }
        Debug.Log("Healing!");
    }

    public void RemoveHealth(float damaged)
    {
        curenthealthValue -= damaged;
        Debug.Log("Damaged!");
        if (curenthealthValue >= 0) return;
        var enemy = GetComponent<Enemy>();
        enemy.Death();
    }
}
