using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [Header("Player Data : ")]
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float playerRunningSpeed;
    [SerializeField] private float playerNormalSpeed;
    [SerializeField] private float playerDashSpeed;
    [SerializeField] private float sprintDuration;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashDuration;
    [SerializeField] private float staminaRegenSpeed;
    [Header("Player Particles Data : ")]
    [SerializeField] private ParticleSystem[] burningDashParticles;
    [Header("Player Transform Data : ")]
    [SerializeField] private Transform particleTransform;
    [Header("Player Rigidbody Data : ")]
    [SerializeField] private Rigidbody playerRigidBody;
    [Header("Player Other Data : ")]
    [SerializeField] private Vector3 lastMovement;
    [SerializeField] private Transform pivotTransform;
    
    private float sprintStamina;
    private float currentDashCooldown;
    private bool isDashing;
    private bool isDashCooldown;
    private Coroutine playerDashCoroutine;
    private IBurnable burning;

    public float NormalizedSprintStamina => sprintStamina / sprintDuration;
    
    void Update()
    {
        PlayerMovement();
        PlayerDash();
        PlayerSprint();
        PlayerDashCooldown();
    }

    public void PlayerMovement()
    {
        if (isDashing) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector3(horizontalInput * playerMovementSpeed, playerRigidBody.velocity.y,
            verticalInput * playerMovementSpeed);

        var movement = new Vector3(horizontalInput, 0, verticalInput);

        if (movement.magnitude > 0)
        {
            lastMovement = movement.normalized;
            particleTransform.forward = lastMovement;
        }
    }

    public void PlayerDash()
    {
        if (isDashing) return;
        
        if (isDashCooldown) return;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            pivotTransform.DOScaleX(1f, 0.1f);
            if (playerDashCoroutine != null)
            {
                StopCoroutine(playerDashCoroutine);
            }
            playerDashCoroutine = StartCoroutine(PlayerDashCoroutine());
            isDashCooldown = true;
        }else if (Input.GetKeyDown(KeyCode.Space))
        {
            pivotTransform.DOScaleX(0.5f, 0.1f);
        }
    }

    public void PlayerDashCooldown()
    {
        if (!isDashCooldown) return;
        
        currentDashCooldown += Time.deltaTime;
        
        if (currentDashCooldown > dashCooldown)
        {
            isDashCooldown = false;
        }
    }

    public void PlayerSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && sprintStamina <= sprintDuration)
        {
            playerMovementSpeed = playerRunningSpeed;
            sprintStamina += Time.deltaTime;
        }
        else
        {
            playerMovementSpeed = playerNormalSpeed;
            if (sprintStamina > 0)
            {
                sprintStamina -= Time.deltaTime * staminaRegenSpeed;
            }
        }
    }

    public IEnumerator PlayerDashCoroutine()
    {
        isDashing = true;

        playerRigidBody.velocity = lastMovement * playerDashSpeed;
        
        foreach (var particle in burningDashParticles)
        {
            particle.Play();
        }

        yield return new WaitForSeconds(dashDuration);

        foreach (var particle in burningDashParticles)
        {
            particle.Stop();
        }

        burning.StartBurn();
        isDashing = false;
    }
}
