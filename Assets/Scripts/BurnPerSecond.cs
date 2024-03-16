using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class BurnPerSecond : MonoBehaviour, IBurnable
{
    [SerializeField] private Health health;
    [SerializeField] private bool isBurning;
    [SerializeField] private float currentBurnDuration;
    [SerializeField] private float burnDamagePerSecond;
    [SerializeField] private float burnDuration;
    [SerializeField] private ParticleSystem playerBurningParticles;

    public bool IsBurning => isBurning;

    private void Update()
    {
        BurningUpdate();
    }

    public void StartBurn()
    {
        isBurning = true;
        playerBurningParticles.Play();
        currentBurnDuration = 0;
    }

    public void BurningUpdate()
    {
        if (!isBurning) return;
        
        currentBurnDuration += Time.deltaTime;
        health.RemoveHealth(Time.deltaTime * burnDamagePerSecond);

        if (currentBurnDuration > burnDuration)
        {
            isBurning = false;
            playerBurningParticles.Stop();
        }
    }
}
