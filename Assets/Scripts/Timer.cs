using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float maxTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    private float currentTimer;
    private bool isRunning = true;

    private void Start()
    {
        currentTimer = maxTimer;
    }

    void Update()
    {
        if (isRunning == false) return;
        
        currentTimer -= Time.deltaTime;
        timerText.text = currentTimer.ToString();
        
        if (currentTimer <= 0 )
        {
            timerText.text = 0.ToString();
            Debug.Log("Game telah selesai!");
            isRunning = false;
        }
    }
}
