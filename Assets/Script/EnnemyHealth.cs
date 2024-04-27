using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
	public int health = 100;
    public int maxHealth = 100;

    // Fonction pour gérer les dégâts subis par l'ennemi
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    // Fonction pour gérer la mort de l'ennemi
    void Die()
    {
        // Ajoute ici les actions à effectuer lorsque l'ennemi meurt, comme jouer une animation de mort, donner des récompenses au joueur, etc.
        Destroy(gameObject); // Détruit l'objet de l'ennemi
    }
}

