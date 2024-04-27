using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public int RespawnSceneIndex; // Indice de la sc�ne de respawn

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Trouve le script PlayerHealth attach� au joueur
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Appelle la fonction TakeDamage pour g�rer la mort du joueur
                playerHealth.TakeDamage(playerHealth.health);
            }

            // Charge la sc�ne de respawn apr�s un court d�lai
            Invoke("RespawnPlayer", 1f);
        }
    }

    void RespawnPlayer()
    {
        SceneManager.LoadScene(RespawnSceneIndex);
    }
}
