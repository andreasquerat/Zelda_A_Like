using UnityEngine;

public class dashAbility : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    private bool isDashing = false;
    private Vector2 dashDirection;
    private float dashTimer = 0f;
    private float dashCooldownTimer = 0f;
    public bool canDash = false;

    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDashing && canDash)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
            transform.Translate(movement * Time.deltaTime);

            // Déclenchement de l'animation de déplacement
            if (movement.magnitude > 0)
            {
                animator.SetBool("IsMoving", true);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTimer <= 0f && canDash)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                StartDash(new Vector2(horizontalInput, verticalInput).normalized);
            }
        }

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

        // Déclenchement de l'animation de dash
        animator.SetTrigger("DashUp");
        animator.SetTrigger("DashDown");
        animator.SetTrigger("DashLeft");
        animator.SetTrigger("DashRight");
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
