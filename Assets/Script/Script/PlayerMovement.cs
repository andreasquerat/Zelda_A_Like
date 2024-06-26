using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;


    public bool canDash = false;
    public bool canAttack = false;

    public void UnlockDash()
    {
        canDash = true;
    }
    public void Unlockatk()
    {
        canAttack = true;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()   
    {
        Vector3 change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        change.Normalize();
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
        }

        myRigidbody.velocity = change * moveSpeed;


     
    }
}
