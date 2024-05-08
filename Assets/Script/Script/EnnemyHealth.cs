using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
	public int health = 100;
    public int maxHealth = 100;

    // Fonction pour g�rer les d�g�ts subis par l'ennemi
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    // Fonction pour g�rer la mort de l'ennemi
    void Die()
    {
        // Ajoute ici les actions � effectuer lorsque l'ennemi meurt, comme jouer une animation de mort, donner des r�compenses au joueur, etc.
        Destroy(gameObject); // D�truit l'objet de l'ennemi
    }
}

