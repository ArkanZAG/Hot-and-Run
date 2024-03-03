using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Movement : MonoBehaviour
{
    [SerializeField] private float playerMovementSpeed;
    [SerializeField] private float playerRunningSpeed;
    [SerializeField] private float playerNormalSpeed;
    [SerializeField] private float playerDashSpeed;
    [SerializeField] private float sprintDuration;
    [SerializeField] private float sprintStamina;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float currentDashCooldown;
    [SerializeField] private float dashDuration;
    [SerializeField] private float burnDuration;
    [SerializeField] private float currentBurnDuration;
    
    [SerializeField] private ParticleSystem[] burningDashParticles;
    [SerializeField] private ParticleSystem playerBurningParticles;

    [SerializeField] private Transform particleTransform;
    
    [SerializeField] private Rigidbody playerRigidBody;

    [SerializeField] private bool isDashing;
    [SerializeField] private bool isDashCooldown;
    [SerializeField] private bool isBurning;

    [SerializeField] private Vector3 lastMovement;

    private Coroutine playerDashCoroutine;

    void Update()
    {
        PlayerMovement();
        PlayerDash();
        PlayerSprint();
        PlayerDashCooldown();
        PlayerIsBurning();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerDashCoroutine != null)
            {
                StopCoroutine(playerDashCoroutine);
            }
            playerDashCoroutine = StartCoroutine(PlayerDashCoroutine());
            isDashCooldown = true;
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

    public void PlayerIsBurning()
    {
        if (!isBurning) return;
        
        currentBurnDuration += Time.deltaTime;

        if (currentBurnDuration > burnDuration)
        {
            isBurning = false;
            playerBurningParticles.Stop();
        }
    }

    public void PlayerSprint()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprintStamina = 0;
        }

        if (Input.GetKey(KeyCode.LeftShift) && sprintStamina <= sprintDuration)
        {
            playerMovementSpeed = playerRunningSpeed;
            sprintStamina += Time.deltaTime;
        }
        else
        {
            playerMovementSpeed = playerNormalSpeed;
        }
    }

    public IEnumerator PlayerDashCoroutine()
    {
        isDashing = true;

        playerRigidBody.velocity = lastMovement * playerDashSpeed;
        playerBurningParticles.Play();
        foreach (var particle in burningDashParticles)
        {
            particle.Play();
        }

        currentBurnDuration = 0;

        yield return new WaitForSeconds(dashDuration);

        foreach (var particle in burningDashParticles)
        {
            particle.Stop();
        }

        isBurning = true;
        isDashing = false;
    }
}
