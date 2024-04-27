using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class EnnemyDamage : MonoBehaviour
{
    public int RespawnSceneIndex; // Indice de la scène de respawn
    public int damage = 1;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();

        // S'assurer que le script PlayerHealth est bien trouvé
        if (playerHealth == null)
        {
            Debug.LogWarning("PlayerHealth not found!");
        }
    }

    void ReactToPlayerDamage()
    {
        if (playerHealth != null && playerHealth.health > 0)
        {
            playerHealth.TakeDamage(damage);
            if (playerHealth.health <= 0)
            {
                RespawnPlayer();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ReactToPlayerDamage();
        }
    }

    void RespawnPlayer()
    {
        // Détruire le joueur avant le respawn pour éviter les doublons
        Destroy(playerHealth.gameObject);

        // Charger la scène de respawn après un court délai
        Invoke("LoadRespawnScene", 1f);
    }

    void LoadRespawnScene()
    {
        SceneManager.LoadScene(RespawnSceneIndex);
    }
}
