using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Score score;

    private void Awake()
    {
        score.onScoreChange.AddListener(Display);
    }

    public void Display(int point)
    {
        scoreText.text = point.ToString();
    }
}
