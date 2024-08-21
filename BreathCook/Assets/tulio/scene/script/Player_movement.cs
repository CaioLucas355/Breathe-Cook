using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
   

    [Header("movimentacao")]
    public float moveSpeed = 5f;

    [Header("Rigdbody")]
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    [Header("")]
    Vector2 movement;

    [Header("animator")]
    private Animator animator;

    [Header("interacao")]
    public GameObject interacao;
    private bool tacolidindo = false;
    public KeyCode botaointeracao = KeyCode.X;
    public KeyCode botaointeracaosair = KeyCode.Z;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // interacao
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("balcaocomida"))
        {
            tacolidindo = true;
        }
        else
        {
            tacolidindo = false;
        }
       
     
    }


    private void FixedUpdate()
    {
        // movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(moveSpeed * movement.x, moveSpeed * movement.y);

        if (movement.x> 0)
        {
            animator.SetInteger("player", 1);
            sr.flipX = false;
        }
        if (rb.velocity.magnitude == 0)
        {
            animator.SetInteger("player", 0);
        }
        if (movement.x < 0)
        {
            animator.SetInteger("player", 1);
            sr.flipX = true;
        }

        if (tacolidindo && Input.GetKeyDown(botaointeracao))
        {
            interacao.SetActive(true);
            Camera.main.transform.position = new Vector3(-18.74f, 0.11f, -10f);
        }

        if (Input.GetKeyDown(botaointeracaosair)) 
        {
            interacao.SetActive(true);
            Camera.main.transform.position = new Vector3(0.037f, 0.11f, -11f);
        }
        
        
    }



}
