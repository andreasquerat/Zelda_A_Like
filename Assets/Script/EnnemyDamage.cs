using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnnemyDamage : MonoBehaviour
{
    public GameObject player;
    public int damage = 1;
    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();

        // S'assurer que le script PlayerHealth est bien trouvé
        if (playerHealth != null)
        {
            // Écouter l'événement OnPlayerDamaged
            playerHealth.OnPlayerDamaged.AddListener(ReactToPlayerDamage);
        }
        else
        {
            Debug.LogWarning("PlayerHealth not found!");
        }
        DontDestroyOnLoad(this);
    }
    void ReactToPlayerDamage()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }

}
