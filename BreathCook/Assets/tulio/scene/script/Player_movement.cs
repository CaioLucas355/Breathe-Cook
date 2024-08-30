using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [Header("comida")]
    

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
    private comidafeita comida;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    // interacao
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balcaocomida"))
        {
            tacolidindo = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("balcaocomida"))
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
             sr.flipX = true;
        }
        if (rb.velocity.magnitude == 0)
        {
            animator.SetInteger("player", 0);
        }
        if (movement.x < 0)
        {
            animator.SetInteger("player", 1);
            sr.flipX = false;
        }

        if (tacolidindo && Input.GetKey(botaointeracao) && GameObject.FindGameObjectWithTag("comidafeita") != true)
        {

            Camera.main.transform.position = new Vector3(-18.74f, 0.11f, -10f);
            // GameObject prefab_comidafeita = GameObject.FindGameObjectWithTag("comidafeita");
            // Destroy(prefab_comidafeita);
        }
        else if (tacolidindo == true && GameObject.FindGameObjectWithTag("comidafeita") == true && Input.GetKey(botaointeracao))
        {
          //  comida = GameObject.FindGameObjectWithTag("comidafeita").GetComponent<comidafeita>();
            Debug.Log("doe a comida");
           
        }

        if (Input.GetKey(botaointeracaosair)) 
        {         
            Camera.main.transform.position = new Vector3(0.037f, 0.11f, -11f);
        }


    }
    


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("descarte") &&  Input.GetKey(botaointeracao))
        {
            GameObject prefab_comidafeita = GameObject.FindGameObjectWithTag("comidafeita");
            Destroy(prefab_comidafeita);
        }
        // comida.tasegurando == true &&
    }




}
