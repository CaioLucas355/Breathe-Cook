using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [Header("movimentacao")]
    public float moveSpeed = 5f;

    [Header("Rigdbody")]
    public Rigidbody2D rb;

    [Header("")]
    Vector2 movement;

    [Header("animator")]
    private Animator animator;
  

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
  

   

    private void FixedUpdate()
    {
        // movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(moveSpeed * movement.x,moveSpeed * movement.y);   

        if (rb.velocity.magnitude !=  0)
        {
            animator.SetInteger("player", 1);
        }
        else
        {
            animator.SetInteger("player", 0);
        }

        //interacao

      //  if (Input.GetKeyDown(KeyCode.X)
         //    {
        
       // }


    }



}
