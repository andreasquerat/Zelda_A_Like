using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public int RespawnSceneIndex; // Indice de la scène de respawn

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Trouve le script PlayerHealth attaché au joueur
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Appelle la fonction TakeDamage pour gérer la mort du joueur
                playerHealth.TakeDamage(playerHealth.health);
            }

            // Charge la scène de respawn après un court délai
            Invoke("RespawnPlayer", 1f);
        }
    }

    void RespawnPlayer()
    {
        SceneManager.LoadScene(RespawnSceneIndex);
    }
}
