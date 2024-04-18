using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashability : MonoBehaviour
{
    public float dashDistance = 5f; // Distance du dash
    public float dashDuration = 0.2f; // Durée du dash en secondes
    public float dashCooldown = 1f; // Temps de recharge du dash en secondes

    private bool isDashing = false;
    private Vector2 dashDirection;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;
    public bool canDash = false;

    private Animator animator; // Référence à l'Animator

    private void Start()
    {
        animator = GetComponent<Animator>(); // Initialiser la référence à l'Animator
    }

    private void Update()
    {
        if (!isDashing && canDash) // Ajout de la vérification de canDash
        {
            // Mouvement normal du personnage
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
            transform.Translate(movement * Time.deltaTime);
        }

        // Déclenchement du dash
        if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTimer <= 0f && canDash) // Ajout de la vérification de canDash
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                StartDash(new Vector2(horizontalInput, verticalInput).normalized);
            }
            if (animator!=null)
            {
                animator.SetTrigger("Dash");
            }
        }

        // Gestion du dash en cours
        if (isDashing)
        {
            dashTimer += Time.deltaTime;

            if (dashTimer >= dashDuration)
            {
                StopDash();
            }
            else
            {
                transform.Translate(dashDirection * dashDistance * Time.deltaTime / dashDuration);
            }
        }

        // Gestion du cooldown du dash
        if (dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

    }


    void StartDash(Vector2 direction)
    {
        isDashing = true;
        dashDirection = direction;
        dashTimer = 0f;
        dashCooldownTimer = dashCooldown;
    }
  
    void StopDash()
    {
        isDashing = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dash_power_up"))
        {
            canDash = true;
            Destroy(other.gameObject);
        }
    }
}
