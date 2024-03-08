using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScore;

    private void Start()
    {
        finalScore.text = PlayerPrefs.GetInt("FinalScore").ToString();
    }
}
