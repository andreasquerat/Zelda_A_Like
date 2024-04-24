using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            playerHealth.TakeDamage(damage);
        }
    }

}
