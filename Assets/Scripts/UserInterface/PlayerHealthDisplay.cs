using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Health playerHealth;

    private void Awake()
    {
        playerHealth.onHealthChanged.AddListener(Display);
    }

    public void Display(float currentHealth, float maxHealth)
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
