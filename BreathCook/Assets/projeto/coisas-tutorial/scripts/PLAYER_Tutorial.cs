using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class PLAYER_Tutorial : MonoBehaviour
{
    DialogueSystem dialogueSystem;
    DialogueSystem1 dialogueSystem1;

    public GameObject seta1;
    public GameObject seta2;
    public GameObject seta3;
    public GameObject seta4;


    [Header("transicao")]
    public static PLAYER_Tutorial instamce;
    public GameObject receitaabrir;
    public GameObject receitaabrir2;
    public GameObject receitaabrir3;

    [Header("screen")]
    public GameObject escuridao;
    public GameObject E;
    public GameObject WASD_SETAS;
    public GameObject X;
    public GameObject V;
    public GameObject F;
    public GameObject Z;
    public GameObject esc;
    public GameObject interacao_cozinha;
    public GameObject interacaoalimento1;
    public GameObject interacaoalimento2;
    public GameObject interacaoalimento3;
    public GameObject interacaoalimento4;
    public GameObject interacaoalimento5;
    public GameObject interacaoalimento6;

    [Header("radio")]
    [SerializeField] private GameObject radio;
    public bool radiofoi;

    [Header("anything")]
    public bool tutorial = true;
    public bool tutorial2 = false;
    public bool tutorial3 = false;
    public bool tutorial4 = false;
    public bool tutorial5 = false;
    public bool tutorial6 = false;
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
    private comidafeita_tutorial comida;
    bool moveFogao, moveCozinha;
    public bool movevolta, moveZ;
    public GameObject comidaAtual;
    private void Awake()
    {
        dialogueSystem = FindObjectOfType<DialogueSystem>();

        instamce = this;
    }

    private void Start()
    {
        moveSpeed = 0;
        animator = GetComponent<Animator>();
        target2 = new Vector3(0.037f, 0.11f, -11f);
        target = new Vector3(-17.966f, 0.11f, -11f);
        cam = Camera.main;
        dialogueSystem1 = DialogueSystem1.instance;
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

        if (Input.GetKey(botaointeracaosair))
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
        if (Mathf.Abs(transform.position.x - NPC_tutorial.Instance.transform.position.x) < 2.5f)
        {
            if (Mathf.Abs(transform.position.y - NPC_tutorial.Instance.transform.position.y) < 2.5f)
            {
                 if (NPC_tutorial.Instance.npedido == 4)
                 {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        dialogueSystem.Next();
                    }
                 }
            }
        }

        if (Input.GetKey(KeyCode.E) & tutorial == true)
        {
            //dialogo 1, ensinando o basico, basico

            dialogueSystem1.Next();
            //desaparece botão E
            escuridao.SetActive(false);
            E.SetActive(false);


            //(aparecer teclas WASD e SETAS)
            
            WASD_SETAS.SetActive(true); 

            tutorial = false;
            tutorial2 = true;
        }

        if (tutorial2 == true & Input.GetKey(KeyCode.W) & DialogueSystem1.instance.currentText == 2)
        {
            WASD_SETAS.SetActive(false);
            interacao_cozinha.SetActive(true);
            moveSpeed = 5;
            tutorial2 = false;
            tutorial3 = true;
        }
        else if (tutorial2 == true & Input.GetKey(KeyCode.A) & DialogueSystem1.instance.currentText == 2)
        {
            WASD_SETAS.SetActive(false);
            interacao_cozinha.SetActive(true);
            moveSpeed = 5;
            tutorial2 = false;
            tutorial3 = true;
        }
        else if (tutorial2 == true & Input.GetKey(KeyCode.S) & DialogueSystem1.instance.currentText == 2)
        {
            WASD_SETAS.SetActive(false);
            interacao_cozinha.SetActive(true);
            moveSpeed = 5;
            tutorial2 = false;
            tutorial3 = true;
        }
        else if (tutorial2 == true & Input.GetKey(KeyCode.D) & DialogueSystem1.instance.currentText == 2)
        {
            WASD_SETAS.SetActive(false);
            interacao_cozinha.SetActive(true);
            moveSpeed = 5;
            tutorial2 = false;
            tutorial3 = true;
        }
        else if (tutorial2 == true & Input.GetKey(KeyCode.DownArrow) & DialogueSystem1.instance.currentText == 2)
        {
            WASD_SETAS.SetActive(false);
            interacao_cozinha.SetActive(true);
            moveSpeed = 5;
            tutorial2 = false;
            tutorial3 = true;
        }
        else if (tutorial2 == true & Input.GetKey(KeyCode.LeftArrow) & DialogueSystem1.instance.currentText == 2)
        {
            WASD_SETAS.SetActive(false);
            interacao_cozinha.SetActive(true);
            moveSpeed = 5;
            tutorial2 = false;
            tutorial3 = true;
        }
        else if (tutorial2 == true & Input.GetKey(KeyCode.RightArrow) & DialogueSystem1.instance.currentText == 2)
        {
            WASD_SETAS.SetActive(false);
            interacao_cozinha.SetActive(true);
            moveSpeed = 5;
            tutorial2 = false;
            tutorial3 = true;
        }
        else if (tutorial2 == true & Input.GetKey(KeyCode.UpArrow) & DialogueSystem1.instance.currentText == 2)
        {
            WASD_SETAS.SetActive(false);
            interacao_cozinha.SetActive(true);
            moveSpeed = 5;
            tutorial2 = false;
            tutorial3 = true;
        }

        if (DialogueSystem1.instance.currentText == 3 && tutorial2 == true)
        {
            WASD_SETAS.SetActive(false);
            interacao_cozinha.SetActive(true);
            tutorial2 = false;
            tutorial3 = true;
        }
       

        if (tutorial3 == true & DialogueSystem1.instance.currentText == 3)
        {
            moveSpeed = 5;
            interacao_cozinha.SetActive(false);
            //z pode voltar 
            Debug.Log("ta func");
            tutorial4 = true;
            tutorial3 = false;
        }
        if (tutorial4 == true & DialogueSystem1.instance.conversaAtual == 1)
        { 

            interacaoalimento1.SetActive(true);
            interacaoalimento2.SetActive(true);
            interacaoalimento3.SetActive(true);
            interacaoalimento4.SetActive(true);

        }

        if (GameObject.FindWithTag("comida"))
        {
            tutorial4 = false;
            tutorial5 = true;

                interacaoalimento1.SetActive(false);
                interacaoalimento2.SetActive(false);
                interacaoalimento3.SetActive(false);
                interacaoalimento4.SetActive(false);
        }
        if (DialogueSystem1.instance.conversaAtual == 1 & DialogueSystem1.instance.currentText > 2)
        {
            interacaoalimento5.SetActive(true);
            interacaoalimento6.SetActive(true);
            tutorial5 = false;
        }
        if (tutorial5 == true & radiofoi == true & GameObject.FindGameObjectWithTag("comidafeita") != true & GameObject.FindGameObjectWithTag("comida") != true)
        { 
            interacaoalimento5.SetActive(false);
            interacaoalimento6.SetActive(false);
        }


    }

  

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("descarte") && Input.GetKey(botaointeracao))
        {
            segura = false;
            Destroy(comidaAtual);
        }
        if (collision.CompareTag("pessoaAentregar") && comidaAtual != null && Input.GetKey(botaointeracao))
        {
            collision.gameObject.GetComponent<NPC_tutorial>().ReceberComida(comidaAtual.GetComponent<comidafeita_tutorial>().comida);

        }
        if (collision.CompareTag("pessoaAentregar2") && comidaAtual != null && Input.GetKey(botaointeracao))
        {
            collision.gameObject.GetComponent<NPC_tutorial>().ReceberComida(comidaAtual.GetComponent<comidafeita_tutorial>().comida);

        }
        if (collision.gameObject.CompareTag("radio") && Input.GetKey(botaointeracao))
        {
            radio.SetActive(true);
            radiofoi = true;
            interacaoalimento5.SetActive(false);
            interacaoalimento6.SetActive(false);

            interacaoalimento1.transform.position = seta1.transform.position;
            interacaoalimento2.transform.position = seta2.transform.position;
            interacaoalimento3.transform.position = seta4.transform.position;
            interacaoalimento4.transform.position = seta3.transform.position;
        }
        // comida.tasegurando == true &&
    }




}
