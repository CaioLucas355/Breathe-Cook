using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    DialogueSystem2 dialogueSystem2;
    public Transform npc;
    public bool readyToSpeak = false;
    public int dialogo;

    [Header("transicao")]
    public static Player_movement instamce;
    public GameObject receitaabrir;
    public GameObject receitaabrir2;
    public GameObject receitaabrir3;


    [Header("radio")]
    [SerializeField] private GameObject radio;

    public bool tutorial = true;
    public bool segura = false;
    private Vector2 target;
    private Vector2 position;
    private Camera cam;
    public float speedcam = 10.0f;
    private Vector3 target2;
    private Vector3 Target;
    [Header("movimentacao")]
    public float moveSpeed = 5f;

    [Header("Rigdbody")]
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    [Header("")]
    Vector2 movement;
    bool podemovernao = false;

    [Header("animator")]
    private Animator animator;

    [Header("interacao")]
    public GameObject interacao;
    private bool tacolidindo = false;
    public KeyCode botaointeracao = KeyCode.X;
    public KeyCode botaointeracaosair = KeyCode.Z;
    public KeyCode botaodepause = KeyCode.Escape;
    private comidafeita comida;
    bool moveFogao, moveCozinha;
    public bool movevolta, moveZ;
    public GameObject comidaAtual;
    private void Awake()
    {
        dialogueSystem2 = FindObjectOfType<DialogueSystem2>();

        instamce = this;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        target2 = new Vector3(0.037f, 0.11f, -11f);
        target = new Vector3(-17.966f, 0.11f, -11f);
        cam = Camera.main;
    }


    private void Update()
    {

    }


    private void FixedUpdate()
    {
        // movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        float step = speedcam * Time.deltaTime;

        rb.velocity = new Vector2(moveSpeed * movement.x, moveSpeed * movement.y);

        if (movement.x > 0)
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

        if (tacolidindo && Input.GetKey(botaointeracao) && GameObject.FindGameObjectWithTag("comidafeita") != true && segura == false)
        {


            Debug.Log("andando");
            moveFogao = true;

            receitaabrir.SetActive(true);
            receitaabrir2.SetActive(true);
            receitaabrir3.SetActive(true);


            // GameObject prefab_comidafeita = GameObject.FindGameObjectWithTag("comidafeita");
            // Destroy(prefab_comidafeita);
        }
        else if (tacolidindo == true && GameObject.FindGameObjectWithTag("comidafeita") == true && segura == false && Input.GetKey(botaointeracao))
        {
            //  comida = GameObject.FindGameObjectWithTag("comidafeita").GetComponent<comidafeita>();
            Debug.Log("doe a comida");

        }

        if (moveFogao == true)
        {
            if (cam.transform.position.x != target.x)
            {
                moveSpeed = 0;
                cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(target.x, target.y, -11), step);

                movevolta = false;
            }
            else
            {
                moveFogao = false;
            }
        }

        if (Input.GetKey(botaointeracaosair) & movevolta == false)
        {

            Debug.Log("voltando");
            movevolta = true;
            receitaabrir.SetActive(false);
            receitaabrir2.SetActive(false);
            receitaabrir3.SetActive(false);
            ReceitaAbrir.Instance.FecharReceitas();

        }
        if (movevolta == true)
        {
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, new Vector3(target2.x, target2.y, -11), step);
            moveFogao = false;
            podemovernao = true;

        }
        else
        {

            movevolta = false;
        }

        if (podemovernao == true && cam.transform.position == new Vector3(0.037f, 0.11f, -11f))
        {

            moveSpeed = 5;
            podemovernao = false;


        }
        if (cam.transform.position == new Vector3(0.037f, 0.11f, -11f))
        {
            moveSpeed = 5;
            podemovernao |= false;


        }

        if (Input.GetKey(botaodepause))
        {

            PauseManager.Instance.AbrirOptions();

        }

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
        if (collision.gameObject.CompareTag("radio"))
        {
            radio.SetActive(false);
        }
        if (collision.CompareTag("pessoaAentregar"))
        {
            readyToSpeak = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("descarte") && Input.GetKey(botaointeracao))
        {
            segura = false;
            Destroy(comidaAtual);
        }

        if (Input.GetKey(botaointeracao) && collision.CompareTag("pessoaAentregar"))
        {
            if (collision.gameObject.GetComponent<MovmentNPC>().sentado && collision.gameObject.GetComponent<MovmentNPC>().historia)
            {
                readyToSpeak = true;
            }
        }

        if (collision.CompareTag("pessoaAentregar") && comidaAtual != null && Input.GetKey(botaointeracao))
        {
            collision.gameObject.GetComponent<MovmentNPC>().ReceberComida(comidaAtual.GetComponent<comidafeita>().comida);

        }
        if (collision.CompareTag("pessoaAentregar2") && comidaAtual != null && Input.GetKey(botaointeracao))
        {
            collision.gameObject.GetComponent<NPC_tutorial>().ReceberComida(comidaAtual.GetComponent<comidafeita>().comida);

        }
        if (collision.gameObject.CompareTag("radio") && Input.GetKey(botaointeracao))
        {
            radio.SetActive(true);

        }

        // comida.tasegurando == true &&
    }

}
