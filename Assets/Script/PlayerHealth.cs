using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;

    public SpriteRenderer playerSr;
    public PlayerMovement playerMovement;
    public UnityEvent OnPlayerDamaged = new UnityEvent();

    void Start()
    {
        health = maxHealth;
        DontDestroyOnLoad(this);
    }
    

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 && playerSr != null && playerMovement != null)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false;
        }
        OnPlayerDamaged.Invoke();
    }

    void Update()
    {
        // Ajoutez des fonctionnalités de mise à jour si nécessaire
    }
}