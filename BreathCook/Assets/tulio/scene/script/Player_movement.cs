using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [Header("transicao")]
    private float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;
    public float speedcam = 10.0f;
    private Vector2 target2;
    private Vector2 Target;
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
        target = new Vector2(0.0f, 0.0f);
        cam = Camera.main;
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
        float step = speedcam * Time.deltaTime;

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
            
            
              Debug.Log("andando");
              cam.transform.position = Vector2.MoveTowards(transform.position, Target, step);
            
            
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

            cam.transform.position = Vector2.MoveTowards(transform.position, target2, step);
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
