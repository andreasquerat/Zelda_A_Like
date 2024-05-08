using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class EnnemyDamage : MonoBehaviour
{
    public int RespawnSceneIndex; // Indice de la sc�ne de respawn
    public int damage = 1;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();

        // S'assurer que le script PlayerHealth est bien trouv�
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
        // D�truire le joueur avant le respawn pour �viter les doublons
        Destroy(playerHealth.gameObject);

        // Charger la sc�ne de respawn apr�s un court d�lai
        Invoke("LoadRespawnScene", 1f);
    }

    void LoadRespawnScene()
    {
        SceneManager.LoadScene(RespawnSceneIndex);
    }
}
