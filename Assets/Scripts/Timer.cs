using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float maxTimer;
    [SerializeField] private TextMeshProUGUI timerText;
    private string victoryScene = "VictoryScene";
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
        timerText.text = currentTimer.ToString("F2");
        
        if (currentTimer <= 0 )
        {
            timerText.text = 0.ToString();
            SceneManager.LoadScene(victoryScene);
            isRunning = false;
        }
    }
}
