using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSprintDisplay : MonoBehaviour
{
    [SerializeField] private Slider playerStamina;
    [SerializeField] private Movement playerDash;

    private void Update()
    {
        playerStamina.value = 1 - playerDash.NormalizedSprintStamina;
    }
}
