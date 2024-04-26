using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 1.5f;
    public int attackDamage = 10;
    public LayerMask enemyLayer;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public bool canAttack = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack();
        }

        // Déterminer la direction de l'attaque
        if (horizontalInput > 0)
        {
            PlayAttackAnimation("AttackRight");
        }
        else if (horizontalInput < 0)
        {
            PlayAttackAnimation("AttackLeft");
        }
        else if (verticalInput > 0)
        {
            PlayAttackAnimation("AttackUp");
        }
        else if (verticalInput < 0)
        {
            PlayAttackAnimation("Attack");
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            EnnemyHealth enemyHealth = enemy.GetComponent<EnnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
            }
        }
    }

    void PlayAttackAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Faux_power_up"))
        {
            canAttack = true;
            Destroy(other.gameObject);
        }
    }
}