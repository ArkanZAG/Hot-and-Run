using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryScreenButton : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button quitButton;

    private string mainMenuScene = "MainMenu";
    private string restartScene = "SampleScene";

    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenuButton);
        restartButton.onClick.AddListener(RestartScene);
        quitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(restartScene);
    }

    private void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
