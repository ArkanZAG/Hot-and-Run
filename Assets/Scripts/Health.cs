using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float curenthealthValue;
    [SerializeField] private float maxHealthValue;

    public UnityEvent<float, float> onHealthChanged;
    public UnityEvent onDeath;

    private void Start()
    {
        onHealthChanged.Invoke(curenthealthValue, maxHealthValue);
    }

    public void AddHealth(float heal)
    {
        curenthealthValue += heal;
        if (curenthealthValue > maxHealthValue)
        {
            curenthealthValue = maxHealthValue;
        }
        onHealthChanged.Invoke(curenthealthValue, maxHealthValue);
    }

    public void RemoveHealth(float damaged)
    {
        curenthealthValue -= damaged;
        onHealthChanged.Invoke(curenthealthValue, maxHealthValue);
        if (curenthealthValue >= 0) return;
        Debug.Log("DIE!");
        onDeath.Invoke();
    }
}
