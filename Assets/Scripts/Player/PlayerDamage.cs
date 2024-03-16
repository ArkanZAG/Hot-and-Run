using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private BurnPerSecond burning;
    private string victoryScene = "VictoryScene";

    private void Start()
    {
        playerHealth.onDeath.AddListener(OnDead);
    }

    private void OnDead()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(victoryScene);
    }

    private void OnTriggerEnter(Collider other)
    {
        var damagealbe = other.GetComponent<IDamageable>();
        if (damagealbe != null)
        {
            damagealbe.OnDamage();
        }
    }


}
